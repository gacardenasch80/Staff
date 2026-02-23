using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure.Services
{
    public interface IAWSCognitoUpdateUserService
    {
        Task<bool> CognitoUserEdition(string oldEmail, string newEmail);
    }

    public class AWSCognitoUpdateUserService : IAWSCognitoUpdateUserService
    {
        private readonly CognitoConfiguration _settings;
        private readonly ServiceConfigurationDTO _s3Settings;
        private IRandomPasswordService _randomPasswordService;

        public AWSCognitoUpdateUserService(IOptions<CognitoConfiguration> settings, IOptions<ServiceConfigurationDTO> s3settings, IRandomPasswordService randomPasswordService)
        {
            _settings = settings.Value;
            _s3Settings = s3settings.Value;
            _randomPasswordService = randomPasswordService;
        }

        /* AWS Cognito User Pool User edition */
        public async Task<bool> CognitoUserEdition(string oldEmail, string newEmail)
        {
            string accessToken = string.Empty;

            AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(_s3Settings.AWSS3.AccessKeyId, _s3Settings.AWSS3.SecretAccessKey, RegionEndpoint.USEast1);

            AttributeType mail = new AttributeType
            {
                Name = "email",
                Value = newEmail
            };

            AttributeType name = new AttributeType
            {
                Name = "name",
                Value = newEmail
            };

            AttributeType userName = new AttributeType
            {
                Name = "preferred_username",
                Value = newEmail
            };

            AttributeType verifyEmail = new AttributeType
            {
                Name = "email_verified",
                Value = "true"
            };

            AdminDeleteUserRequest adminDeleteUserRequest = new AdminDeleteUserRequest()
            {
                Username = oldEmail,
                UserPoolId = _settings.CandidatePoolId,
            };

            AdminCreateUserRequest adminCreateUserRequest = new AdminCreateUserRequest()
            {
                Username = newEmail,
                UserPoolId = _settings.CandidatePoolId,
                UserAttributes = new List<AttributeType>
                {
                    mail,
                    name,
                    userName,
                    verifyEmail
                },
                TemporaryPassword = _randomPasswordService.GenerateRandomPasswordNineLetters()
            };

            AdminDeleteUserResponse adminDeleteUserResponse = new AdminDeleteUserResponse();

            try
            {
                adminDeleteUserResponse = await provider.AdminDeleteUserAsync(adminDeleteUserRequest);
            }
            catch (Exception ex)
            {
            }

            try
            {
                AdminCreateUserResponse adminCreateUserResponse = await provider.AdminCreateUserAsync(adminCreateUserRequest);

                if (adminCreateUserResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    AdminSetUserPasswordRequest adminSetUserPasswordRequest = new AdminSetUserPasswordRequest
                    {
                        Username = newEmail,
                        UserPoolId = _settings.CandidatePoolId,
                        Password = adminCreateUserRequest.TemporaryPassword,
                        Permanent = true
                    };

                    AdminSetUserPasswordResponse adminSetUserPasswordResponse = await provider.AdminSetUserPasswordAsync(adminSetUserPasswordRequest);

                    if (adminSetUserPasswordResponse.HttpStatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        /* AWS Cognito User Pool Sign Up */
        private async Task<bool> CognitoSignUp(string email, string password)
        {
            BasicAWSCredentials awsCredentials = new BasicAWSCredentials("AKIAWYHMV525PYQTR3NJ", "rdbJfGCSofXGnlqAcLtuFDCYb46g5+y+FlwQJBvM"); //cognitoAdmin

            AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(awsCredentials, RegionEndpoint.USEast1);

            SignUpRequest signUpRequest = new SignUpRequest
            {
                Username = email,
                Password = password,
                ClientId = _settings.CandidateAppClientId,
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType()
                    {
                        Name = "email",
                        Value = email
                    }
                }
            };

            try
            {
                SignUpResponse signUpResponse = await provider.SignUpAsync(signUpRequest);
            }
            catch (UsernameExistsException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
