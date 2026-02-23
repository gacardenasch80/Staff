using Amazon.S3;
using Amazon.S3.Model;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.KeyVault.SecretsModels;
using GemBox.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using S3bucketDemo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

//using Syncfusion.DocIO;
//using Syncfusion.DocIO.DLS;
//using Syncfusion.OfficeChart;
//using Syncfusion.DocIORenderer;
//using Syncfusion.DocToPDFConverter;
//using Syncfusion.Pdf;

namespace S3bucketDemo.Services
{
    public interface IAWSS3FileService
    {
        Task<string> UploadFile(IFormFile uploadFile);
        Task<List<string>> UploadCVFileRaw(string uploadFile, string folder);
        Task<string> UploadFile(IFormFile uploadFileName, string folder);
        Task<string> UploadFilesWithPathBucketName(IFormFile uploadFile, string folder, string parentEmail);
        Task<List<string>> UploadCVFile(IFormFile uploadFileName, string folder);
        Task<List<string>> UploadCVFileMigration(string uploadFileName, string folder);
        Task<List<string>> FilesList();
        Task<MemoryStream> GetFile(string key);
        Task<bool> UpdateFile(CVDTO uploadFileName, string key);
        Task<bool> DeleteFile(string key);
        Task CopyToOtherFolderS3(string originBucket, string destinationBucket, string originFolder, string destinationFolder, string fileId);
    }
    public class AWSS3FileService : IAWSS3FileService
    {
        private readonly IAWSS3BucketHelper _AWSS3BucketHelper;
        private readonly ServiceConfigurationDTO _settings;

        public AWSS3FileService(IAWSS3BucketHelper AWSS3BucketHelper, IOptions<ServiceConfigurationDTO> settings)
        {
            this._AWSS3BucketHelper = AWSS3BucketHelper;
            _settings = settings.Value;
        }

        public async Task<string> UploadFile(IFormFile uploadFile, string folder)
        {
            try
            {
                // Get the current directory.
                string currentPath = Directory.GetCurrentDirectory();
                string identifier;
                bool success;

                // Combine with the new route
                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                System.IO.Directory.CreateDirectory(folderPath);
                string path = Path.GetFullPath(Path.Combine(folderPath, uploadFile.FileName));

                using (var fsSource = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    uploadFile.CopyTo(fsSource);
                    string fileExtension = Path.GetExtension(uploadFile.FileName);
                    var fileName = string.Empty;
                    identifier = DateTime.Now.Ticks.ToString();
                    fileName = folder + "/" + $"{identifier}{fileExtension}";
                    success = await _AWSS3BucketHelper.UploadFile(fsSource, fileName);

                    File.Delete(path);
                    if (success == true)
                        return fileName;
                    else
                        return null;
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<string> UploadFilesWithPathBucketName(IFormFile uploadFile, string folder, string parentEmail)
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory();
                string identifier = string.Empty;
                bool success = false;

                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                Directory.CreateDirectory(folderPath);
                string path = Path.GetFullPath(Path.Combine(folderPath, uploadFile.FileName));

                using (FileStream fsSource = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    uploadFile.CopyTo(fsSource);

                    string fileExtension = Path.GetExtension(uploadFile.FileName);
                    string fileName = string.Empty;
                    identifier = parentEmail;

                    fileName = folder + "/" + $"{identifier}{fileExtension}";

                    success = await _AWSS3BucketHelper.UploadFile(fsSource, fileName);
                    //success = await _AWSS3BucketHelper.DeleteFile(identifier);

                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex)
                    {

                    }

                    if (success)
                        return "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + fileName;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<string>> UploadCVFile(IFormFile uploadFile, string folder)
        {
            try
            {
                // Get the current directory.
                List<string> fileNames = new List<string>();
                string currentPath = Directory.GetCurrentDirectory();
                string identifier;
                bool success;
                bool savepdf = false;

                // Combine with the new route
                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                System.IO.Directory.CreateDirectory(folderPath);
                string path = Path.GetFullPath(Path.Combine(folderPath, uploadFile.FileName));

                using (var fsSource = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    uploadFile.CopyTo(fsSource);
                    string fileExtension = Path.GetExtension(uploadFile.FileName);
                    var fileName = string.Empty;
                    identifier = DateTime.Now.Ticks.ToString();
                    fileName = folder + "/" + $"{identifier}{fileExtension}";
                    fileNames.Add(fileName);
                    success = await _AWSS3BucketHelper.UploadFile(fsSource, fileName);
                    if (fileExtension == ".docx" || fileExtension == ".doc")
                        savepdf = true;
                }

                File.Delete(path);
                if (success == true)
                    return fileNames;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> UploadCVFileMigration(string uploadFile, string folder)
        {
            try
            {
                List<string> fileNames = new List<string>();
                string currentPath = Directory.GetCurrentDirectory();
                string identifier;
                bool success;

                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                System.IO.Directory.CreateDirectory(folderPath);

                using (var fsSource = new FileStream(uploadFile, FileMode.Open, FileAccess.ReadWrite))
                {
                    string fileExtension = Path.GetExtension(fsSource.Name);
                    var fileName = string.Empty;
                    identifier = DateTime.Now.Ticks.ToString();
                    fileName = folder + "/" + $"{identifier}{fileExtension}";
                    fileNames.Add(fileName);
                    success = await _AWSS3BucketHelper.UploadFile(fsSource, fileName);
                }

                File.Delete(uploadFile);
                if (success == true)
                    return fileNames;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> UploadCVFileRaw(string uploadFile, string folder)
        {
            try
            {
                List<string> fileNames = new List<string>();
                string currentPath = Directory.GetCurrentDirectory();
                string identifier;
                bool success;

                string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
                System.IO.Directory.CreateDirectory(folderPath);

                using (var fsSource = new FileStream(uploadFile, FileMode.Open, FileAccess.ReadWrite))
                {
                    string fileExtension = Path.GetExtension(fsSource.Name);
                    var fileName = string.Empty;
                    identifier = DateTime.Now.Ticks.ToString();
                    fileName = folder + "/" + $"{identifier}{fileExtension}";
                    fileNames.Add(fileName);
                    success = await _AWSS3BucketHelper.UploadFileRaw(fsSource, fileName);
                }

                File.Delete(uploadFile);
                if (success == true)
                    return fileNames;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> FilesList()
        {
            try
            {
                ListVersionsResponse listVersions = await _AWSS3BucketHelper.FilesList();
                return listVersions.Versions.Select(c => c.Key).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<MemoryStream> GetFile(string key)
        {
            try
            {
                var fileStream = await _AWSS3BucketHelper.GetFile(key);
                if (fileStream == null)
                {
                    Exception ex = new Exception("File Not Found");
                    throw ex;
                }
                else
                {
                    return fileStream;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateFile(CVDTO uploadFileName, string key)
        {
            try
            {
                var path = Path.Combine("Files", uploadFileName.ToString() + ".png");
                using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return await _AWSS3BucketHelper.UploadFile(fsSource, key);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteFile(string key)
        {
            try
            {
                return await _AWSS3BucketHelper.DeleteFile(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Upload file to S3 */
        public async Task<string> UploadFile(IFormFile uploadFile)
        {
            try
            {
                // Get the current directory.
                string currentPath = Directory.GetCurrentDirectory();
                string identifier;
                bool success;

                // Combine with the new route
                string folderPath = Path.GetFullPath(currentPath);
                Directory.CreateDirectory(folderPath);
                string path = Path.GetFullPath(Path.Combine(folderPath, uploadFile.FileName));

                using (FileStream fsSource = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    uploadFile.CopyTo(fsSource);
                    string fileExtension = Path.GetExtension(uploadFile.FileName);

                    string fileName = string.Empty;
                    identifier = DateTime.Now.Ticks.ToString();

                    fileName = $"{uploadFile.FileName.Replace(fileExtension, "")}_{identifier}{fileExtension}";

                    success = await _AWSS3BucketHelper.UploadFileToTest(fsSource, fileName);

                    File.Delete(path);

                    if (success == true)
                        return fileName;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;

            }
        }

        public async Task CopyToOtherFolderS3(string originBucket, string destinationBucket, string originFolder, string destinationFolder, string fileId)
        {
            CopyObjectRequest copyObjectRequest = new CopyObjectRequest
            {
                SourceBucket = originBucket + "/" + originFolder,
                DestinationBucket = destinationBucket + "/" + destinationFolder,
                SourceKey = fileId,
                DestinationKey = fileId,
                CannedACL = S3CannedACL.NoACL,
                StorageClass = S3StorageClass.Standard,
            };

            await _AWSS3BucketHelper.CopyFile(copyObjectRequest);
        }
    }
}
