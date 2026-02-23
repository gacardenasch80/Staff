using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.Services;
using S3bucketDemo.Helpers;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure.RemoteInfraestructure
{
    public class RecruiteeRemoteRepository : IRecruiteeRemoteRepository
    {
        private readonly IAWSS3BucketHelper _AWSS3BucketHelper;
        private readonly IHttpClientFactory _httpClient;
        private readonly ICandidateRepository _candidateRepository;

        private readonly ICVRepository _cvRepository;
        //private readonly IMigrationService _migrationService;
        private readonly IRecruiteeCandidateRawRepository _recruiteeCandidateRawRepository;
        private readonly IAWSS3FileService _aWSS3FileService;

        private const string token = "R0drYXo0VEhpcW0rMDB0TmUxS3pWUT09";
        private const string companyId = "26296";

        public RecruiteeRemoteRepository(ICandidateRepository candidateRepository, /*IMigrationService migrationService,*/ IRecruiteeCandidateRawRepository recruiteeCandidateRawRepository,
            ICVRepository cvRepository, IHttpClientFactory httpClient, IAWSS3BucketHelper AWSS3FileService, IAWSS3FileService aWSS3FileService)
        {
            _candidateRepository = candidateRepository;
            _AWSS3BucketHelper = AWSS3FileService;
            _recruiteeCandidateRawRepository = recruiteeCandidateRawRepository;
            _cvRepository = cvRepository;
            _aWSS3FileService = aWSS3FileService;
            //_migrationService = migrationService;
            _httpClient = httpClient;
        }

        public async Task<List<RecruiteeCandidateInDTO>> GetCandidates()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    List<RecruiteeCandidateInDTO> result = new List<RecruiteeCandidateInDTO>();
                    int i = 0;
                    int j = 0;
                    //foreach (CandidateRecruiteeInDTO candidate in initialResult.candidates)
                    while (j < 1000)
                    {
                        CandidateRecruiteeInDTO candidate = initialResult.candidates[i];
                        i++;
                        HttpResponseMessage responseOne;
                        if (candidate.emails.Count > 0)
                        {
                            var existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(candidate.emails[0]);
                            if (existCandidateByEmail)
                                continue;

                            responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                            if (responseOne.IsSuccessStatusCode)
                            {
                                string contentOne = await responseOne.Content.ReadAsStringAsync();
                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);
                                j++;
                                result.Add(resultOne);
                            }
                        }
                    }

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

        public async Task<bool> GetCandidatesFirstInfoRaw()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                List<RecruiteeCandidateRaw> result = new List<RecruiteeCandidateRaw>();

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    if (initialResult != null && initialResult.candidates != null && initialResult.candidates.Count > 0)
                    {
                        foreach (CandidateRecruiteeInDTO candidate in initialResult.candidates)
                        {
                            try
                            {
                                string candidateJSON = JsonSerializer.Serialize(candidate);

                                RecruiteeCandidateRaw candidateRaw = new RecruiteeCandidateRaw
                                {
                                    RecruiteeId = (int)candidate.id,
                                    BasicData = candidateJSON
                                };

                                result.Add(candidateRaw);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                }

                bool isCreated = await _recruiteeCandidateRawRepository.AddRange(result);

                if (isCreated)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GetCandidatesSecondInfoRaw()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                List<RecruiteeCandidateRaw> result = await _recruiteeCandidateRawRepository.GetAll();

                if (result != null && result.Count > 0)
                {
                    foreach (RecruiteeCandidateRaw candidate in result)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.RecruiteeId.ToString());

                            if (response.IsSuccessStatusCode)
                            {
                                string contentOne = await response.Content.ReadAsStringAsync();

                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                string resultJSON = JsonSerializer.Serialize(resultOne);

                                candidate.OtherData = resultJSON;

                                bool idUpdated = await _recruiteeCandidateRawRepository.Update(candidate);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GetNotesRaw()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                List<RecruiteeCandidateRaw> result = await _recruiteeCandidateRawRepository.GetAll();

                if (result != null && result.Count > 0)
                {
                    foreach (RecruiteeCandidateRaw candidate in result)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.RecruiteeId.ToString() + "/notes");

                            if (response.IsSuccessStatusCode)
                            {
                                string contentOne = await response.Content.ReadAsStringAsync();

                                RecruiteeNotesinDTO resultOne = JsonSerializer.Deserialize<RecruiteeNotesinDTO>(contentOne);

                                string resultJSON = JsonSerializer.Serialize(resultOne);

                                candidate.Notes = resultJSON;

                                bool idUpdated = await _recruiteeCandidateRawRepository.Update(candidate);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GetCVsRaw()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                List<RecruiteeCandidateRaw> result = await _recruiteeCandidateRawRepository.GetAll();

                if (result != null && result.Count > 0)
                {
                    foreach (RecruiteeCandidateRaw candidate in result)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.RecruiteeId.ToString());

                            if (response.IsSuccessStatusCode)
                            {
                                string contentOne = await response.Content.ReadAsStringAsync();

                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                string url = resultOne.candidate.cv_original_url;//await _migrationService.SaveCVRawAsync(resultOne.candidate.cv_original_url, resultOne.candidate.name, candidate.RecruiteeId);
                                string name = resultOne.candidate.name;
                                int candidateId = candidate.RecruiteeId;

                                /**/

                                // Get the current directory.
                                string currentPath = Directory.GetCurrentDirectory();
                                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                                System.IO.Directory.CreateDirectory(folderPath);

                                Uri uri = new Uri(url);
                                string filename = name + "_";
                                string filePath;

                                try
                                {

                                    if (uri.IsFile || true)
                                    {
                                        filename += Path.GetFileName(uri.LocalPath);
                                        filePath = folderPath + "/" + filename;
                                        WebClient Client = new WebClient();

                                        Client.DownloadFile(url, filePath);
                                    }
                                    else
                                        continue;

                                    var responseOne = await _aWSS3FileService.UploadCVFileRaw(filePath, "CV");
                                    if (responseOne == null)
                                        return false;

                                    CV cvUser = new CV();
                                    cvUser.CandidateId = candidateId;
                                    cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
                                    cvUser.CvIdentifier = responseOne[0];
                                    cvUser.CvIdentifierLink = "https://recruitee-bucket-prod.s3.amazonaws.com/" + responseOne[0];
                                    if (responseOne.Count == 2)
                                        cvUser.CvIdentifierLink = "https://recruitee-bucket-prod.s3.amazonaws.com/" + responseOne[1];
                                    await _cvRepository.DeleteOverViewCv(candidateId);
                                    cvUser.OverViewCv = true;

                                    cvUser.Name = name;
                                    cvUser.FileTypeId = 6;
                                    cvUser.UploadDate = DateTime.Now.ToString();

                                    /**/

                                    candidate.CV = cvUser.CvIdentifierLink;

                                    bool idUpdated = await _recruiteeCandidateRawRepository.Update(candidate);
                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GetPhotosRaw()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                List<RecruiteeCandidateRaw> result = await _recruiteeCandidateRawRepository.GetAll();

                if (result != null && result.Count > 0)
                {
                    foreach (RecruiteeCandidateRaw candidate in result)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.RecruiteeId.ToString());

                            if (response.IsSuccessStatusCode)
                            {
                                string contentOne = await response.Content.ReadAsStringAsync();

                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                string photo_url = resultOne.candidate.photo_url;

                                /**/

                                if (photo_url == null || photo_url == "")
                                    continue;
                                // Get the current directory.
                                string currentPath = Directory.GetCurrentDirectory();
                                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                                System.IO.Directory.CreateDirectory(folderPath);

                                Uri uri = new Uri(photo_url);
                                string filename = "";
                                string filePath;

                                try
                                {

                                    if (uri.IsFile || true)
                                    {
                                        filename = Path.GetFileName(uri.LocalPath);
                                        filePath = folderPath + "/" + filename;
                                        WebClient Client = new WebClient();

                                        Client.DownloadFile(photo_url, filePath);
                                    }
                                    else
                                        continue;

                                    var responseOne = await _aWSS3FileService.UploadCVFileRaw(filePath, "Photo");
                                    if (responseOne == null)
                                        continue;

                                    candidate.Photo = "https://recruitee-bucket-prod.s3.amazonaws.com/" + responseOne[0];

                                    bool idUpdated = await _recruiteeCandidateRawRepository.Update(candidate);
                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RecruiteeCandidateInDTO>> GetExsistsCandidates()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    List<RecruiteeCandidateInDTO> result = new List<RecruiteeCandidateInDTO>();

                    foreach (var candidate in initialResult.candidates)
                    {
                        try
                        {
                            HttpResponseMessage responseOne;

                            if (candidate.emails.Count > 0)
                            {
                                var existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(candidate.emails[0]);
                                if (existCandidateByEmail)
                                {
                                    responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                                    if (responseOne.IsSuccessStatusCode)
                                    {
                                        string contentOne = await responseOne.Content.ReadAsStringAsync();

                                        RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                        result.Add(resultOne);

                                        //if (result.Count == 100)
                                        //{
                                        //    break;
                                        //}
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

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

        public async Task<List<RecruiteeCandidateInDTO>> GetExsistsCandidatesAndSecondBigMigration()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    List<RecruiteeCandidateInDTO> result = new List<RecruiteeCandidateInDTO>();

                    foreach (var candidate in initialResult.candidates)
                    {
                        try
                        {
                            HttpResponseMessage responseOne;

                            if (candidate.emails.Count > 0)
                            {
                                var existCandidateByEmail = await _candidateRepository.CandidateExistByEmailAndSecondBigMigration(candidate.emails[0]);
                                if (existCandidateByEmail)
                                {
                                    responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                                    if (responseOne.IsSuccessStatusCode)
                                    {
                                        string contentOne = await responseOne.Content.ReadAsStringAsync();

                                        RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                        result.Add(resultOne);

                                        //if (result.Count == 100)
                                        //{
                                        //    break;
                                        //}
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

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

        public async Task<List<CandidateRecruiteeInDTO>> GetExsistsCandidatesSingle()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    List<CandidateRecruiteeInDTO> result = new List<CandidateRecruiteeInDTO>();

                    result = initialResult.candidates;

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

        public async Task<List<RecruiteeCandidateInDTO>> GetCandidatesWhitOutMail()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (!response.IsSuccessStatusCode)
                    return null;

                string content = await response.Content.ReadAsStringAsync();

                CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                List<RecruiteeCandidateInDTO> result = new List<RecruiteeCandidateInDTO>();
                int i = 0;
                int j = 0;
                foreach (CandidateRecruiteeInDTO candidate in initialResult.candidates)
                {
                    //CandidateRecruiteeInDTO candidate = initialResult.candidates[i];
                    //i++;
                    HttpResponseMessage responseOne;
                    if (candidate.emails.Count == 0)
                    {
                        responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                        if (responseOne.IsSuccessStatusCode)
                        {
                            try
                            {
                                string contentOne = await responseOne.Content.ReadAsStringAsync();

                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                j++;

                                result.Add(resultOne);
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }

        public async Task<List<NoteRecruitee>> MigrateNotes(List<CandidateRecruiteeInDTO> candidates)
        {
            HttpClient client = _httpClient.CreateClient("Recruitee");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<NoteRecruitee> parentNotes = new List<NoteRecruitee>();

            int aux = 0;

            foreach (var candidate in candidates)
            {
                try
                {
                    HttpResponseMessage responseOne;

                    if (candidate.emails.Count > 0)
                    {
                        var existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(candidate.emails[0]);
                        if (existCandidateByEmail)
                        {
                            Candidate candidateDB = await _candidateRepository.GetByEmail(candidate.emails[0]);

                            if (candidateDB.CreationDate.Contains("12/15/2022") || candidateDB.CreationDate.Contains("12/16/2022"))
                            {
                                responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString() + "/notes");

                                //responseOne = await client.GetAsync($"/c/{companyId}/candidates/25459536/notes");

                                if (responseOne.IsSuccessStatusCode)
                                {
                                    string contentOne = await responseOne.Content.ReadAsStringAsync();

                                    RecruiteeNotesinDTO resultOne = JsonSerializer.Deserialize<RecruiteeNotesinDTO>(contentOne);

                                    if (resultOne.notes != null && resultOne.notes.Length > 0)
                                    {
                                        foreach (NoteRecruitee note in resultOne.notes)
                                        {
                                            note.candidateId = candidateDB.CandidateId;

                                            parentNotes.Add(note);
                                        }

                                        aux++;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }

                //if (aux >= 2)
                //    break;
            }

            return parentNotes;
        }

        public async Task<bool> GetCandidatesCV()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    //string dir = @"C:\recruitee_HV\";

                    // Get the current directory.
                    string currentPath = Directory.GetCurrentDirectory();
                    string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                    System.IO.Directory.CreateDirectory(folderPath);

                    // If directory does not exist, create it
                    //if (!Directory.Exists(dir))
                    //{
                    //    Directory.CreateDirectory(dir);
                    //}

                    //foreach (CandidateRecruiteeInDTO candidate in initialResult.candidates)
                    for (int i = 0; i < 10; i++)
                    {
                        CandidateRecruiteeInDTO candidate = initialResult.candidates[i];

                        HttpResponseMessage responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                        if (responseOne.IsSuccessStatusCode)
                        {
                            try
                            {
                                string contentOne = await responseOne.Content.ReadAsStringAsync();

                                RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);


                                //WebClient clientCv = new WebClient();
                                Uri uri = new Uri(resultOne.candidate.cv_url);
                                //Stream stream = await clientCv.OpenReadTaskAsync(uri);
                                //var result = await _AWSS3BucketHelper.UploadFile(stream, "recruiteeCvs");

                                string filename = resultOne.candidate.name + "_";
                                string path = Path.GetFullPath(Path.Combine(folderPath, filename));

                                WebClient Client = new WebClient();
                                Client.DownloadFile(resultOne.candidate.cv_url, folderPath + filename);

                                if (uri.IsFile || true)
                                {
                                    //using (var fsSource = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                                    //{
                                    //    //stream.Position = 0;
                                    //    //uploadFile.CopyTo(fsSource);
                                    //    string fileName = string.Empty;
                                    //    fileName = "Recruitee" + "/" + $"{filename}.pdf";
                                    //    //fileName = folder + "/" + uploadFileName.FileName;
                                    //    var success = await _AWSS3BucketHelper.UploadFile(fsSource, fileName);
                                    //    File.Delete(path);
                                    //    if (success == true)
                                    //        return fileName;
                                    //    else
                                    //        return null;
                                    //}
                                    //filename += Path.GetFileName(uri.LocalPath);

                                    //WebClient Client = new WebClient();
                                    //Client.DownloadFile(resultOne.candidate.cv_url, folderPath + filename);
                                }
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public async Task<RecruiteeCandidateInDTO> GetCandidateById(int id)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync($"/c/{companyId}/candidates/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    RecruiteeCandidateInDTO result = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(content);

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

        public async Task<List<RecruiteeCandidateInDTO>> GetNotExsistsCandidates()
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("Recruitee");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync($"/c/{companyId}/candidates");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    CandidatesRecruiteeInDTO initialResult = JsonSerializer.Deserialize<CandidatesRecruiteeInDTO>(content);

                    List<RecruiteeCandidateInDTO> result = new List<RecruiteeCandidateInDTO>();

                    foreach (var candidate in initialResult.candidates)
                    {
                        try
                        {
                            HttpResponseMessage responseOne;

                            //if (candidate.emails.Count > 0)
                            {
                                //var existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(candidate.emails[0]);
                                //if (!existCandidateByEmail)
                                {
                                    responseOne = await client.GetAsync($"/c/{companyId}/candidates/" + candidate.id.ToString());

                                    if (responseOne.IsSuccessStatusCode)
                                    {
                                        string contentOne = await responseOne.Content.ReadAsStringAsync();

                                        RecruiteeCandidateInDTO resultOne = JsonSerializer.Deserialize<RecruiteeCandidateInDTO>(contentOne);

                                        result.Add(resultOne);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

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
    }
}
