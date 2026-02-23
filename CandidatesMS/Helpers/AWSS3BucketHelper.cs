using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace S3bucketDemo.Helpers
{
    public interface IAWSS3BucketHelper
    {
        Task<bool> UploadFile(Stream inputStream, string fileName);
        Task<bool> UploadFileRaw(Stream inputStream, string fileName);
        Task<bool> UploadFileToTest(Stream inputStream, string fileName);
        Task<ListVersionsResponse> FilesList();
        Task<MemoryStream> GetFile(string key);
        Task<bool> DeleteFile(string key);
        Task<CopyObjectResponse> CopyFile(CopyObjectRequest copyObjectRequest);
    }
    public class AWSS3BucketHelper : IAWSS3BucketHelper
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly ServiceConfigurationDTO _settings;

        public AWSS3BucketHelper(IAmazonS3 s3Client, IOptions<ServiceConfigurationDTO> settings)
        {
            this._amazonS3 = s3Client;
            this._settings = settings.Value;
        }
        public async Task<bool> UploadFile(Stream inputStream, string fileName)
        {
            var credentials = new BasicAWSCredentials(_settings.AWSS3.AccessKeyId, _settings.AWSS3.SecretAccessKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            using var client = new AmazonS3Client(credentials, config);

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = inputStream,
                    BucketName = _settings.AWSS3.BucketName,
                    Key = fileName,
                    CannedACL = S3CannedACL.NoACL
                };

                var fileTransferUtility = new TransferUtility(client);

                await fileTransferUtility.UploadAsync(uploadRequest); 

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UploadFileRaw(Stream inputStream, string fileName)
        {
            var credentials = new BasicAWSCredentials(_settings.AWSS3.AccessKeyId, _settings.AWSS3.SecretAccessKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            using var client = new AmazonS3Client(credentials, config);

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = inputStream,
                    BucketName = "recruitee-bucket-prod",
                    Key = fileName,
                    CannedACL = S3CannedACL.NoACL
                };

                var fileTransferUtility = new TransferUtility(client);

                await fileTransferUtility.UploadAsync(uploadRequest);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> UploadFileToTest(Stream inputStream, string fileName)
        {
            var credentials = new BasicAWSCredentials(_settings.AWSS3Textract.AccessKeyId, _settings.AWSS3Textract.SecretAccessKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            using var client = new AmazonS3Client(credentials, config);

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = inputStream,
                    BucketName = _settings.AWSS3Textract.BucketName,
                    Key = fileName,
                    CannedACL = S3CannedACL.NoACL
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                //if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return true;
                //else
                //    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ListVersionsResponse> FilesList()
        {
            return await _amazonS3.ListVersionsAsync(_settings.AWSS3.BucketName);
        }

        [AllowAnonymous]
        public async Task<MemoryStream> GetFile(string key)
        {
            BasicAWSCredentials credentials = new(_settings.AWSS3.AccessKeyId, _settings.AWSS3.SecretAccessKey);

            AmazonS3Config config = new()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            using AmazonS3Client client = new(credentials, config);

            try
            {
                MemoryStream memoryStream = new();

                GetObjectRequest request = new()
                {
                    BucketName = _settings.AWSS3.BucketName,
                    Key = key
                };

                using (GetObjectResponse response = await client.GetObjectAsync(request))

                using (Stream responseStream = response.ResponseStream)
                {
                    responseStream.CopyTo(memoryStream);
                }

                return memoryStream;
            }
            catch (AmazonS3Exception ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteFile(string key)
        {
            try
            {
                DeleteObjectResponse response = await _amazonS3.DeleteObjectAsync(_settings.AWSS3.BucketName, key);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CopyObjectResponse> CopyFile(CopyObjectRequest copyObjectRequest)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_settings.AWSS3.AccessKeyId, _settings.AWSS3.SecretAccessKey);
                var config = new AmazonS3Config
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast1
                };

                using var client = new AmazonS3Client(credentials, config);

                CopyObjectResponse response = await client.CopyObjectAsync(copyObjectRequest);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}