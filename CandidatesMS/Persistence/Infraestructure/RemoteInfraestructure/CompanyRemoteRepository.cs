using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Repositories.RemoteRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure.RemoteInfraestructure
{
    public class CompanyRemoteRepository : ICompanyRemoteRepository
    {
        private readonly IHttpClientFactory _httpClient;

        public CompanyRemoteRepository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePostulationsByCandidateId(int candidateId, string token)
        {
            token = token.Split(" ")[1];

            HttpClient client = _httpClient.CreateClient("Companies");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync($"/api/postulation/candidateid/{candidateId}");

            return true;
        }

        public async Task<bool> DeletePostulationsById(int postulationId, string token)
        {
            token = token.Split(" ")[1];

            HttpClient client = _httpClient.CreateClient("Companies");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync($"/api/postulation/{postulationId}/2");

            return true;
        }

        public async Task<bool> DeleteCandidate_TalentGroupsById(int candidate_talentGroupId, string token)
        {
            token = token.Split(" ")[1];

            HttpClient client = _httpClient.CreateClient("Companies");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync($"/api/candidate_talentGroup/{candidate_talentGroupId}");

            return true;
        }


        public async Task<bool> DeleteFiledAndDeletedPostulationsByCandidateId(int candidateId, string token)
        {
            token = token.Split(" ")[1];

            HttpClient client = _httpClient.CreateClient("Companies");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync($"/api/postulation/filedanddeleted/candidateId/{candidateId}");

            return true;
        }

        public async Task<bool> isMaster(string token)
        {
            token = token.Split(" ")[1];

            HttpClient client = _httpClient.CreateClient("Companies");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"/api/companyuser/isMaster");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                bool result = (bool)json.SelectToken("obj");
                return result;
            }
            return false;
        }

        public async Task<TechnicalAbilityRemoteDTO> GetTechnicalAbilityById(int technicalAbilityId, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/api/technicalAbility/{technicalAbilityId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    TechnicalAbilityRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<TechnicalAbilityRemoteDTO>(content);

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<JobProfessionRemoteDTO> GetJobProfessionById(int jobProfessionId, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/job/jobProfession/{jobProfessionId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    JobProfessionRemoteDTO result = new JobProfessionRemoteDTO()
                    {
                        JobProfessionId = (int)json.SelectToken("obj.jobProfessionId"),
                        Profession = (string)json.SelectToken("obj.profession"),
                        ProfessionEnglish = (string)json.SelectToken("obj.professionEnglish")
                    };

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<bool> AddAndAttachTagToCandidate(int candidateId, TagInDTO tagDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(tagDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/candidate_tag/add/{candidateId}", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TechnicalAbilityRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<TechnicalAbilityRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddAndAttachEmailToMemberUser(DataMentionEmailDTO dataMentionEmailDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(dataMentionEmailDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/emailByMentionUser/{dataMentionEmailDTO.Language}", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    DataMentionEmailDTO result = System.Text.Json.JsonSerializer.Deserialize<DataMentionEmailDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [RequestSizeLimit(60000000)]
        public async Task<bool> AddSendEmailToCandidateFromCompany(MailSendOutDTO mailSendOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("subject", mailSendOutDTO.Subject);
                parameters.Add("mailescription", mailSendOutDTO.Description);
                parameters.Add("emailMember", mailSendOutDTO.EmailMember);
                parameters.Add("emailCandidate", mailSendOutDTO.EmailCandidate);
                parameters.Add("creatorName", mailSendOutDTO.CreatorName);
                parameters.Add("candidateName", mailSendOutDTO.CandidateName);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                MultipartFormDataContent form = new MultipartFormDataContent();
                HttpContent contentSubject = new StringContent(mailSendOutDTO.Subject);
                HttpContent contentDescription = new StringContent(mailSendOutDTO.Description);
                HttpContent contentEmailMember = new StringContent(mailSendOutDTO.EmailMember);
                HttpContent contentEmailCandidate = new StringContent(mailSendOutDTO.EmailCandidate);
                HttpContent contentCreatorName = new StringContent(mailSendOutDTO.CreatorName);
                HttpContent contentCandidateName = new StringContent(mailSendOutDTO.CandidateName);
               

                form.Headers.ContentType.MediaType = "multipart/form-data";
                form.Add(contentSubject, "subject");
                form.Add(contentDescription, "description");
                form.Add(contentEmailMember, "emailMember");
                form.Add(contentEmailCandidate, "emailCandidate");
                form.Add(contentCreatorName, "creatorName");
                form.Add(contentCandidateName, "candidateName");

                if(mailSendOutDTO.FormFile == null)
                {
                    HttpResponseMessage response = await client.PostAsync($"api/notification/emailCandidateByMemberUser", form);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        DataMentionEmailDTO result = System.Text.Json.JsonSerializer.Deserialize<DataMentionEmailDTO>(content);
                        return true;
                    }
                }
                else
                {
                    foreach (IFormFile file in mailSendOutDTO.FormFile)
                    {
                        StreamContent streamContent = new StreamContent(file.OpenReadStream());
                        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
                        form.Add(streamContent, "FormFile", file.FileName);
                    }

                    HttpResponseMessage response = await client.PostAsync($"api/notification/emailCandidateByMemberUser", form);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        DataMentionEmailDTO result = System.Text.Json.JsonSerializer.Deserialize<DataMentionEmailDTO>(content);
                        return true;
                    }
                    
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddAndAttachSourceToCandidate(int candidateId, SourceInDTO sourceDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(sourceDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/candidate_source/add/{candidateId}", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TechnicalAbilityRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<TechnicalAbilityRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public async Task<MemberUserRemoteDTO> GetMemberUserById(int memberUserId, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/api/memberUser/byMemberUserId/{memberUserId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var result = new MemberUserRemoteDTO()
                    {
                        MemberUserId = (int)json.SelectToken("obj.memberUserId"),
                        Name = (string)json.SelectToken("obj.name"),
                        Surname = (string)json.SelectToken("obj.surname"),
                        Email = (string)json.SelectToken("obj.email"),
                        RoleName = (string)json.SelectToken("obj.roleName"),
                        CompanyUserId = (int)json.SelectToken("obj.companyUserId")
                    };

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<MemberUserRemoteDTO> GetMemberUserByEmail(string email, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/api/memberUser/memberByemail/{email}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var result = new MemberUserRemoteDTO()
                    {
                        MemberUserId = (int)json.SelectToken("obj.memberUserId"),
                        Name = (string)json.SelectToken("obj.name"),
                        Surname = (string)json.SelectToken("obj.surname"),
                        Email = (string)json.SelectToken("obj.email"),
                        RoleName = (string)json.SelectToken("obj.roleName"),
                        Photo = (string)json.SelectToken("obj.photo"),
                        CompanyUserId = (int)json.SelectToken("obj.companyUserId")
                    };

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<JobIdNameDTO> GetJobMiniById(int jobid)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Companies");

                HttpResponseMessage response = await client.GetAsync($"/api/job/mini/{jobid}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);

                    List<QuestionInDTO> questions = new List<QuestionInDTO>();

                    try
                    {
                        JToken questionsJToken = json.SelectToken("obj.questions");

                        QuestionInDTO[] questionsArray = questionsJToken.ToObject<QuestionInDTO[]>();

                        if (questionsArray != null && questionsArray.Length > 0)
                        {
                            for (int i = 0; i < questionsArray.Length; i++)
                            {
                                questions.Add(questionsArray[i]);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    var result = new JobIdNameDTO()
                    {
                        JobId = (int)json.SelectToken("obj.jobId"),
                        Name = (string)json.SelectToken("obj.name"),
                        Description = (string)json.SelectToken("obj.description"),
                        JobPostingStausId = (int)json.SelectToken("obj.jobPostingStausId"),
                        Questions = questions != null && questions.Count > 0 ? questions : new List<QuestionInDTO>()
                    };

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<TalentGroupNameDTO> GetTalentGroupMiniById(int talentGroupId)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Companies");

                HttpResponseMessage response = await client.GetAsync($"/api/talentGroup/mini/{talentGroupId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var result = new TalentGroupNameDTO()
                    {
                        TalentGroupId = (int)json.SelectToken("obj.talentGroupId"),
                        Name = (string)json.SelectToken("obj.name"),
                        Description = (string)json.SelectToken("obj.description"),
                    };

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<MemberByToken> GetResponseValidateActionByPermission(string validationString, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/permissionactionuser/memberUserFromCandidate/{validationString}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> GetResponseValidateActionByPermissionNew(string validationString, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/permissionActionUser/validatePermissionByAction/{validationString}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<TagListInDTO>> GetTagsByCompanyUser(int companyUserId, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/tag/companyUser/{companyUserId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    TagInStructureDTO result = System.Text.Json.JsonSerializer.Deserialize<TagInStructureDTO>(content);
                    
                    return result.obj;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<List<SourceListInDTO>> GetSourcesByCompanyUser(int companyUserId, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/source/companyUser/{companyUserId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    SourceInStructureDTO result = System.Text.Json.JsonSerializer.Deserialize<SourceInStructureDTO>(content);

                    return result.obj;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<MemberByToken> GetMemberUserFromCandidate(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/memberUser/memberFromCandidate");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<MemberByToken> SendCodeEmailCandidate(CandidateDTO candidateDTO, int language)
        {
            try
            {
                //token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(candidateDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/memberUser/sendCandidateCode/{language}", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<Postulation>> GetPostulationsFromCandidate(string token, int id)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/postulation/byCandidateId/{id}");
                var str2 = response.Content.ReadAsStringAsync().Result;
                
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    PostulationDTO result = System.Text.Json.JsonSerializer.Deserialize<PostulationDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<Postulation>> GetPostulations(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/postulation");
                var str2 = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    PostulationDTO result = System.Text.Json.JsonSerializer.Deserialize<PostulationDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<Candidate_TG>> GetCandidate_TalentGroups(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/candidate_talentGroup");
                var str2 = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Models.RemoteModels.In.Candidate_TGDTO result = System.Text.Json.JsonSerializer.Deserialize<Models.RemoteModels.In.Candidate_TGDTO>(content);
                    return result.obj;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> AddPostulationFromAnalyze(PostulationAnalyzeOutDTO postulationAnalyzeOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(postulationAnalyzeOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/postulation/postulationFromAnalyze", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddTalentGroupFromAnalyze(TalentGroupAnalyzeOutDTO talentGroupAnalyzeOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(talentGroupAnalyzeOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/candidate_TalentGroup/talentGroupFromAnalyze", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<PostulationJobNameInDTO>> GetAllPostulationsWithName(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/postulation/allPostulationsWithJobName");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    PostulationJobInDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<PostulationJobInDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<PostulationJobNameInDTO>> GetAllPostulationsWithNameAndColourFlag(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/postulation/allPostulationsWithJobNameAndEvaluations");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    PostulationJobInDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<PostulationJobInDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<PostulationInDTO>> GetAllPostulationsByCompany(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/postulation/byCandidateId/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    PostulationInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<PostulationInStructureDTO>(content);

                    List<PostulationInDTO> result = resultObject.obj;

                    return result;
                }
                else
                    return new List<PostulationInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<PostulationInDTO>> GetAllPostulationsByCompanyWithoutFiledJobs(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/postulation/withoutFiled/byCandidateId/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    PostulationInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<PostulationInStructureDTO>(content);

                    List<PostulationInDTO> result = resultObject.obj;

                    return result;
                }
                else
                    return new List<PostulationInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<PostulationQuestionsAnswersInDTO>> GetAnswersByCandidateIdOrderByPostulation(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/answer/getByCandidateIdOrderByPostulation/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    PostulationQuestionsAnswersInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<PostulationQuestionsAnswersInStructureDTO>(content);

                    List<PostulationQuestionsAnswersInDTO> result = resultObject.obj;

                    return result;
                }
                else
                    return new List<PostulationQuestionsAnswersInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<TalentGroupsInDTO>> GetAllTalentGroupsByCompany(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/candidate_talentgroup/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    TalentgroupsInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<TalentgroupsInStructureDTO>(content);

                    List<TalentGroupsInDTO> result = resultObject.obj;

                    return result;
                }
                else
                    return new List<TalentGroupsInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<CandidateTalentGroupNameInDTO>> GetAllCandidateTalentWithName(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/candidate_TalentGroup/allCandidateTalentGroupsWithName");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateTalentNameDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateTalentNameDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<CandidateTalentGroupNameInDTO>> GetAllCandidateTalentWithNameAndColourFlag(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/candidate_TalentGroup/allCandidateTalentGroupsWithNameAndEvaluations");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateTalentNameDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateTalentNameDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<MemberByToken>> GetAllMemberUserByToken(string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/memberUser/allMemberByToken");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    MemberUserAllDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<MemberUserAllDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetCandidateIdsFromJobId(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/postulation/candidateIdsFromJobId", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetCandidateIdsFromTalentGroupId(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate_talentGroup/candidateIdsFromTalentGroupId", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromJobId(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/postulation/AllcandidateIdsFromJobId", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromTalentGroupId(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate_talentGroup/AllcandidateIdsFromTalentGroupId", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> ExsistCandidate_TagsByTagAndCandidateId(int tagId, int candidateId, string token)
        {

            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/candidate_tag/exists/byTagAndCandidateId/{tagId}/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public async Task<bool> ExsistCandidate_SourcesBySourceAndCandidateId(int sourceId, int candidateId, string token)
        {

            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/candidate_source/exists/bySourceAndCandidateId/{sourceId}/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public async Task<CandidateIdAndTagResponseDTO> GetCandidateIdsFromTags(string token, SearchByIdAndTextWithPaginationDTO search)
        {

            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate_tag/candidateFromTagSearch", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithTagDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithTagDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndSourceResponseDTO> GetCandidateIdsFromSource(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate_source/candidateFromSourceSearch", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithSourceDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithSourceDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromJobSearch(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/postulation/AllcandidateIdsFromJobSearch", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromTalentGroupSearch(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate_talentGroup/AllcandidateIdsFromTalentGroupSearch", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntCandidateWithPostulationCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntCandidateWithPostulationCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<JobProffesionIdSearchResponseDTO> GetAllJobProfessionsIdFromSearch(string token, SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(search);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/job/JobProfessionSearch", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListIntJobProfessionCountDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<ListIntJobProfessionCountDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> AddNotificationFromRequest(NotificationDTO notificationOutDTO, int language)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Companies");

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/AddNotificationRequest/{language}", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationFromDeleteMember(NotificationDTO notificationOutDTO, int language, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/AddNotificationDeleteMemberUser/{language}", byteContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationFromDeleteMemberFromMaster(NotificationDTO notificationOutDTO, int language, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/AddNotificationDeleteMemberUserFromMaster", byteContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationFromDeleteCandidateFromCandidate(NotificationDTO notificationOutDTO, int language, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/AddNotificationDeleteFromCandidate/{language}", byteContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationFromDeleteHiringFileFromCandidate(NotificationAttachedFileDTO notificationOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/DeleteHiringFile", byteContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationFromDeleteHiringFileByHASHFromCandidate(NotificationAttachedFileDTO notificationOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/DeleteHiringFileByHASH", byteContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //MemberUserRelationShipRemoteDTO result = System.Text.Json.JsonSerializer.Deserialize<MemberUserRelationShipRemoteDTO>(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<CandidateTagInDTO>> GetAllCandidateTags()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Companies");

                HttpResponseMessage response = await client.GetAsync($"api/candidate_tag");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateTagInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateTagInStructureDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return new List<CandidateTagInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<CandidateTagInDTO>> GetAllCandidateTagsByCandidateId(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/candidate_tag/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateTagInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateTagInStructureDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return new List<CandidateTagInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<CandidateSourceInDTO>> GetAllCandidateSources()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Companies");

                HttpResponseMessage response = await client.GetAsync($"api/candidate_source");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateSourceInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateSourceInStructureDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return new List<CandidateSourceInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<CandidateSourceInDTO>> GetAllCandidateSourcesByCandidateId(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"api/candidate_source/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidateSourceInStructureDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<CandidateSourceInStructureDTO>(content);

                    var result = resultObject.obj;

                    return result;
                }
                else
                    return new List<CandidateSourceInDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<EventInDTO>> GetAllEventByCandidateId(string token, int candidateId)
        {
            try
            {
                token = token.Split(" ")[1];
                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"/api/Event/getEventsByCandidateAndCompanyId/{candidateId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    EventResponseDTO resultObject = System.Text.Json.JsonSerializer.Deserialize<EventResponseDTO>(content);

                    List<EventInDTO> events = new List<EventInDTO>();

                    if (resultObject != null)
                        events = resultObject.obj;

                    return events;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> AddToDevDeployed(string candidateJSON, string token)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient();
                client.BaseAddress = new Uri("http://localhost:54761");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var buffer = Encoding.UTF8.GetBytes(candidateJSON);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"/api/candidate", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationEditCandidateEmailFromMaster(NotificationAttachedFileDTO notificationOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);

                var buffer = Encoding.UTF8.GetBytes(myContent);

                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/editCandidateEmailFromMaster", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> AddNotificationEditCandidateDocumentFromMaster(NotificationAttachedFileDTO notificationOutDTO, string token)
        {
            try
            {
                token = token.Split(" ")[1];

                HttpClient client = _httpClient.CreateClient("Companies");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var myContent = JsonConvert.SerializeObject(notificationOutDTO);

                var buffer = Encoding.UTF8.GetBytes(myContent);

                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"api/notification/editCandidateDocumentFromMaster", byteContent);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
