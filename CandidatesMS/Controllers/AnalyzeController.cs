using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Infraestructure.Services;
using S3bucketDemo.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using CandidatesMS.Models;
using Microsoft.Extensions.Primitives;
using Npgsql;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Services;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzeController : ControllerBase
    {
        private readonly ConnectionStringDTO _connectionString;

        private readonly IMemberUserRepository _memberUserRepository;

        private readonly IAWSS3FileService _AWSS3FileService;
        private readonly IAWSCognitoUpdateUserService _AWSCognitoUpdateUserService;
        private readonly IValidateMethodsService _validateMethodsService;

        private readonly ICompanyRemoteRepository _companyRemoteRepository;

        private const string quote = "\"";

        /* Constructor */
        public AnalyzeController
        (
            IMemberUserRepository memberUserRepository,

            IAWSS3FileService AWSS3FileService,
            IAWSCognitoUpdateUserService AWSCognitoUpdateUserService,
            IValidateMethodsService validateMethodsService,

            ICompanyRemoteRepository companyRemoteRepository,
            
            IOptions<ConnectionStringDTO> connectionString
        )
        {
            _connectionString = connectionString.Value;

            _memberUserRepository = memberUserRepository;

            _AWSS3FileService = AWSS3FileService;
            _AWSCognitoUpdateUserService = AWSCognitoUpdateUserService;
            _validateMethodsService = validateMethodsService;

            _companyRemoteRepository = companyRemoteRepository;
        }

        [HttpPost("uploadFiles")]
        public async Task<IActionResult> UploadFilesToAnalyze([FromForm] CandidateAnalyzeDTO candidateAnalyzeDTO)
        {
            try
            {
                List<string> fileNameList = new List<string>();
                List<string> jobIdList = new List<string>();

                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddCandidatesFromAnalysis";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                MemberUser remoteMemberUser = await _memberUserRepository.GetByEmail(candidateAnalyzeDTO.emailMemberUser);

                Guid guid = Guid.NewGuid();
                string guidString = guid.ToString();


                DataTable table = new DataTable();
                string sqlDataSource = _connectionString.ConnectionString;
                NpgsqlDataReader myReader = null;

                FileGroupQueueDTO fileGroup = new FileGroupQueueDTO
                {
                    filegroupguid = guidString,
                    emailmemberuser = candidateAnalyzeDTO.emailMemberUser,
                    namememberuser = remoteMemberUser.Name,
                    surnnamememberuser = remoteMemberUser.Surname,
                    creationdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")
                };

                IEnumerable<Task> tasks = candidateAnalyzeDTO.files.Select(async file =>
                {
                    string fileName = await _AWSS3FileService.UploadFile(file);

                    if (fileName != null)
                    {
                        fileNameList.Add(fileName);
                    }

                    AnalyzeFileDTO analyzeFile = new AnalyzeFileDTO
                    {
                        EmailMemberUser = candidateAnalyzeDTO.emailMemberUser,
                        FileIdentifier = fileName,
                        Jobs = candidateAnalyzeDTO.jobs,
                        TalentGroups = candidateAnalyzeDTO.talentGroups,
                        NumberPages = candidateAnalyzeDTO.numberPages,
                        CompanyUserId = remoteMemberUser.CompanyUserId
                    };

                    /**/

                    List<JobIdNameDTO> jobs = new List<JobIdNameDTO>();

                    if (candidateAnalyzeDTO.jobs != null && candidateAnalyzeDTO.jobs.Count > 0)
                    {
                        foreach (int jobId in candidateAnalyzeDTO.jobs)
                        {
                            JobIdNameDTO jobFull = await _companyRemoteRepository.GetJobMiniById(jobId);

                            if (jobFull != null)
                                jobs.Add(jobFull);
                        }
                    }

                    string jobsString = JsonConvert.SerializeObject(jobs);

                    /**/

                    List<TalentGroupNameDTO> tgs = new List<TalentGroupNameDTO>();

                    if (candidateAnalyzeDTO.talentGroups != null && candidateAnalyzeDTO.talentGroups.Count > 0)
                    {
                        foreach (int talentGroupId in candidateAnalyzeDTO.talentGroups)
                        {
                            TalentGroupNameDTO tgFull = await _companyRemoteRepository.GetTalentGroupMiniById(talentGroupId);

                            if (tgFull != null)
                            {
                                tgs.Add(tgFull);
                            }
                        }
                    }

                    string talentGroupsString = JsonConvert.SerializeObject(tgs);

                    /**/

                    analyzeFile.JobsFull = jobsString;
                    analyzeFile.TalentGroupsFull = talentGroupsString;

                    string jsonData = JsonConvert.SerializeObject(analyzeFile);

                    AnalyzeCVQueueDTO analyzeCV = new AnalyzeCVQueueDTO
                    {
                        filegroupguid = guidString,
                        parameters = jsonData,
                        creationdate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")
                    };

                    string query = @"INSERT INTO " + quote + "AnalyzeCVQueue" + quote + "(parameters, filegroupguid, emailmemberuser, namememberuser, surnamememberuser, creationdate) VALUES " +
                    "(@parameters, @filegroupguid, @emailmemberuser, @namememberuser, @surnamememberuser, @creationdate)";

                    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                    {
                        myCon.Open();

                        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@parameters", jsonData);
                            myCommand.Parameters.AddWithValue("@emailmemberuser", fileGroup.emailmemberuser);
                            myCommand.Parameters.AddWithValue("@namememberuser", fileGroup.namememberuser);
                            myCommand.Parameters.AddWithValue("@surnamememberuser", fileGroup.surnnamememberuser);
                            myCommand.Parameters.AddWithValue("@filegroupguid", fileGroup.filegroupguid);
                            myCommand.Parameters.AddWithValue("@creationdate", fileGroup.creationdate);

                            myReader = await myCommand.ExecuteReaderAsync();
                            table.Load(myReader);

                            //myReader.Close();
                            myCon.Close();
                        }
                    }
                });

                string query = @"INSERT INTO " + quote + "FileGroupQueue" + quote + "(filegroupguid, emailmemberuser, namememberuser, surnamememberuser, creationdate, isprocessed, issuccess) " +
                    "VALUES (@filegroupguid, @emailmemberuser, @namememberuser, @surnamememberuser, @creationdate, @isprocessed, @issuccess)";

                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();

                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@filegroupguid", fileGroup.filegroupguid);
                        myCommand.Parameters.AddWithValue("@emailmemberuser", fileGroup.emailmemberuser);
                        myCommand.Parameters.AddWithValue("@namememberuser", fileGroup.namememberuser);
                        myCommand.Parameters.AddWithValue("@surnamememberuser", fileGroup.surnnamememberuser);
                        myCommand.Parameters.AddWithValue("@creationdate", fileGroup.creationdate);
                        myCommand.Parameters.AddWithValue("@isprocessed", false);
                        myCommand.Parameters.AddWithValue("@issuccess", false);

                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);

                        //myReader.Close();
                        myCon.Close();
                    }
                }

                await Task.WhenAll(tasks);

                return Created("", new { message = "Hojas de vida almacenadas exitosamente", obj = guidString });
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null || ex.InnerException.ToString() == "")
                    return StatusCode(500, new { message = ex.Message });

                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        /* PATCH method. Upload & analyze files */
        [AllowAnonymous] 
        [HttpPatch("cognitoUser")]
        public async Task<IActionResult> UploadAndAnalyzeFile([FromBody] ChangeEmailCognitoDTO emails)
        {
            try
            {
                bool isEdited = false;

                isEdited = await _AWSCognitoUpdateUserService.CognitoUserEdition(emails.OldEmail, emails.NewEmail);

                if (isEdited)
                    return Created("", new { message = "Usuario editado", email = emails.NewEmail });

                return BadRequest(new { message = "Procesado exitosamente" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null || ex.InnerException.ToString() == "")
                    return StatusCode(500, new { message = ex.Message });

                return StatusCode(500, new { message = ex.InnerException });
            }
        }
    }
}
