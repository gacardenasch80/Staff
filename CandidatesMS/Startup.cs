using Amazon.S3;
using CandidatesMS.Helpers;
using CandidatesMS.Infraestructure;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Persistence.Infraestructure.Mailer;
using CandidatesMS.Persistence.Infraestructure.RemoteInfraestructure;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Persistence.InfrastructureCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using CandidatesMS.ServicesCompany;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using S3bucketDemo.Helpers;
using S3bucketDemo.Services;
using System;
using System.Net.Http;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace CandidatesMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* Secrets in AppSettings */ 
            
            string Region = Configuration["Region"];

            string KeyVaultURLFromSecret = Configuration["KeyVaultURL"];

            string AzureKeyVaultAccessTenantId = Configuration["AzureKeyVaultAccessTenantId"];
            string AzureKeyVaultAccessClientId = Configuration["AzureKeyVaultAccessClientId"];
            string AzureKeyVaultAccessClientSecret = Configuration["AzureKeyVaultAccessClientSecret"];

            string ConnectionStringSecret = Configuration["ConnectionStringSecret"];
            string ConnectionStringSecretCompany = Configuration["ConnectionStringSecretCompany"];

            string CandidateURLSecret = Configuration["CandidateURLSecret"];
            string CompanyURLSecret = Configuration["CompanyURLSecret"];
            string RecruiteeSecret = Configuration["RecruiteeURLSecret"];

            string AWSS3BucketSecret = Configuration["AWSS3BucketSecret"];
            string AWSS3AccessKeyIdSecret = Configuration["AWSS3AccessKeyIdSecret"];
            string AWSS3SecretAccessKeySecret = Configuration["AWSS3SecretAccessKeySecret"];

            string AWSS3TextractBucketSecret = Configuration["AWSS3TextractBucketSecret"];
            string AWSS3TextractAccessKeyIdSecret = Configuration["AWSS3TextractAccessKeyIdSecret"];
            string AWSS3TextractSecretAccessKeySecret = Configuration["AWSS3TextractSecretAccessKeySecret"];

            string AWSCognitoRegionSecret = Configuration["AWSCognitoRegionSecret"];
            string AWSCognitoCandidatePoolIdSecret = Configuration["AWSCognitoCandidatePoolIdSecret"];
            string AWSCognitoCandidateAppClientIdSecret = Configuration["AWSCognitoCandidateAppClientIdSecret"];
            string AWSCognitoCompanyPoolIdSecret = Configuration["AWSCognitoCompanyPoolIdSecret"];
            string AWSCognitoCompanyAppClientIdSecret = Configuration["AWSCognitoCompanyAppClientIdSecret"];

            string MailSettingsDisplayNameSecret = Configuration["MailSettingsDisplayNameSecret"];
            string MailSettingsMailImapSecret = Configuration["MailSettingsMailImapSecret"];
            string MailSettingsPasswordImapSecret = Configuration["MailSettingsPasswordImapSecret"];
            string MailSettingsHostImapSecret = Configuration["MailSettingsHostImapSecret"];
            string MailSettingsPortImapSecret = Configuration["MailSettingsPortImapSecret"];
            string MailSettingsMailSecret = Configuration["MailSettingsMailSecret"];
            string MailSettingsPasswordSecret = Configuration["MailSettingsPasswordSecret"];
            string MailSettingsHostSecret = Configuration["MailSettingsHostSecret"];
            string MailSettingsPortSecret = Configuration["MailSettingsPortSecret"];

            string connectionString = string.Empty;
            string connectionStringCompany = string.Empty;

            string candidateURL = string.Empty;
            string companyURL = string.Empty;
            string recruiteeURL = string.Empty;

            /* Azure Key Vault */

            string KeyVaultURL = KeyVaultURLFromSecret;

            AzureKeyVaultSecretsDTO AzureKeyVaultSecret = new()
            {
                TenantId = AzureKeyVaultAccessTenantId,
                ClientId = AzureKeyVaultAccessClientId,
                ClientSecret = AzureKeyVaultAccessClientSecret
            };

            ClientSecretCredential AzureClientSecretCredential = new
            (
                AzureKeyVaultSecret.TenantId,
                AzureKeyVaultSecret.ClientId,
                AzureKeyVaultSecret.ClientSecret
            );

            SecretClientOptions AzureKeyValueOptions = new()
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(1),
                    MaxDelay = TimeSpan.FromSeconds(5),
                    MaxRetries = 3,
                    Mode = RetryMode.Exponential
                 }
            };

            SecretClient AzureKeyValue = new
            (
                new Uri(KeyVaultURL),
                AzureClientSecretCredential,
                AzureKeyValueOptions
            );

            /* Connection Strings */

            KeyVaultSecret connectionStringSecret = AzureKeyValue.GetSecret(ConnectionStringSecret);
            connectionString = connectionStringSecret.Value;

            KeyVaultSecret connectionStringSecretCompany = AzureKeyValue.GetSecret(ConnectionStringSecretCompany);
            connectionStringCompany = connectionStringSecretCompany.Value;

            /* URLs */

            KeyVaultSecret candidateURLSecret = AzureKeyValue.GetSecret(CandidateURLSecret);
            candidateURL = candidateURLSecret.Value;

            KeyVaultSecret companyURLSecret = AzureKeyValue.GetSecret(CompanyURLSecret);
            companyURL = companyURLSecret.Value;

            KeyVaultSecret recruiteeURLSecret = AzureKeyValue.GetSecret(RecruiteeSecret);
            recruiteeURL = recruiteeURLSecret.Value;

            /* S3 */

            KeyVaultSecret S3BucketNameSecret = AzureKeyValue.GetSecret(AWSS3BucketSecret);
            KeyVaultSecret S3AccessKeyIdSecret = AzureKeyValue.GetSecret(AWSS3AccessKeyIdSecret);
            KeyVaultSecret S3SecretAccessKeySecret = AzureKeyValue.GetSecret(AWSS3SecretAccessKeySecret);
            AWSS3ConfigurationDTO AWSS3 = new()
            {
                BucketName = S3BucketNameSecret.Value,
                SecretAccessKey = S3SecretAccessKeySecret.Value,
                AccessKeyId = S3AccessKeyIdSecret.Value
            };

            KeyVaultSecret S3TextractBucketSecret = AzureKeyValue.GetSecret(AWSS3TextractBucketSecret);
            KeyVaultSecret S3TextractAccessKeyIdSecret = AzureKeyValue.GetSecret(AWSS3TextractAccessKeyIdSecret);
            KeyVaultSecret S3TextractSecretAccessKeySecret = AzureKeyValue.GetSecret(AWSS3TextractSecretAccessKeySecret);
            AWSS3ConfigurationDTO AWSS3Textract = new()
            {
                BucketName = S3TextractBucketSecret.Value,
                SecretAccessKey = S3TextractSecretAccessKeySecret.Value,
                AccessKeyId = S3TextractAccessKeyIdSecret.Value
            };

            ServiceConfigurationDTO serviceConfiguration = new()
            {
                AWSS3 = AWSS3,
                AWSS3Textract = AWSS3Textract
            };

            /* Cognito */

            KeyVaultSecret CognitoRegionSecret = AzureKeyValue.GetSecret(AWSCognitoRegionSecret);
            KeyVaultSecret CognitoCandidatePoolIdSecret = AzureKeyValue.GetSecret(AWSCognitoCandidatePoolIdSecret);
            KeyVaultSecret CognitoCandidateAppClientIdSecret = AzureKeyValue.GetSecret(AWSCognitoCandidateAppClientIdSecret);
            KeyVaultSecret CognitoCompanyPoolIdSecret = AzureKeyValue.GetSecret(AWSCognitoCompanyPoolIdSecret);
            KeyVaultSecret CognitoCompanyAppClientIdSecret = AzureKeyValue.GetSecret(AWSCognitoCompanyAppClientIdSecret);

            CognitoConfiguration cognitoConfiguration = new()
            {
                Region = CognitoRegionSecret.Value,
                CandidatePoolId = CognitoCandidatePoolIdSecret.Value,
                CandidateAppClientId = CognitoCandidateAppClientIdSecret.Value,
                CompanyPoolId = CognitoCompanyPoolIdSecret.Value,
                CompanyAppClientId = CognitoCompanyAppClientIdSecret.Value
            };

            /* Mailer */

            KeyVaultSecret MailDisplayNameSecret = AzureKeyValue.GetSecret(MailSettingsDisplayNameSecret);
            KeyVaultSecret MailImapSecret = AzureKeyValue.GetSecret(MailSettingsMailImapSecret);
            KeyVaultSecret MailPasswordImapSecret = AzureKeyValue.GetSecret(MailSettingsPasswordImapSecret);
            KeyVaultSecret MailHostImapSecret = AzureKeyValue.GetSecret(MailSettingsHostImapSecret);
            KeyVaultSecret MailPortImapSecret = AzureKeyValue.GetSecret(MailSettingsPortImapSecret);
            KeyVaultSecret MailSecret = AzureKeyValue.GetSecret(MailSettingsMailSecret);
            KeyVaultSecret MailPasswordSecret = AzureKeyValue.GetSecret(MailSettingsPasswordSecret);
            KeyVaultSecret MailHostSecret = AzureKeyValue.GetSecret(MailSettingsHostSecret);
            KeyVaultSecret MailPortSecret = AzureKeyValue.GetSecret(MailSettingsPortSecret);

            MailSettingsDTO mailSettings = new()
            {
                DisplayName = MailDisplayNameSecret.Value,
                MailImap = MailImapSecret.Value,
                PasswordImap = MailPasswordImapSecret.Value,
                HostImap = MailHostImapSecret.Value,
                PortImap = int.Parse(MailPortImapSecret.Value),
                Mail = MailSecret.Value,
                Password = MailPasswordSecret.Value,
                Host = MailHostSecret.Value,
                Port = int.Parse(MailPortSecret.Value)
            };

            /**/

            services.AddCors(options => options.AddPolicy("MyAllowSpecificOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Content-Disposition", "downloadfilename");
            }));

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            });

            services.AddControllersWithViews(options => options.Filters.Add(new AuthorizeFilter()));

            services.AddAWSService<IAmazonS3>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CandidateRepository>();

            /* Configure options to use in all the code */

            services.Configure<ConnectionStringDTO>(options => options.ConnectionString = connectionString);

            services.Configure<ServiceConfigurationDTO>(options => options.AWSS3 = serviceConfiguration.AWSS3);
            services.Configure<ServiceConfigurationDTO>(options => options.AWSS3Textract = serviceConfiguration.AWSS3Textract);

            services.Configure<CognitoConfiguration>(options => options.Region = cognitoConfiguration.Region);
            services.Configure<CognitoConfiguration>(options => options.CandidatePoolId = cognitoConfiguration.CandidatePoolId);
            services.Configure<CognitoConfiguration>(options => options.CandidateAppClientId = cognitoConfiguration.CandidateAppClientId);
            services.Configure<CognitoConfiguration>(options => options.CompanyPoolId = cognitoConfiguration.CompanyPoolId);
            services.Configure<CognitoConfiguration>(options => options.CompanyAppClientId = cognitoConfiguration.CompanyAppClientId);

            services.Configure<MailSettingsDTO>(options => options.DisplayName = mailSettings.DisplayName);
            services.Configure<MailSettingsDTO>(options => options.Mail = mailSettings.Mail);
            services.Configure<MailSettingsDTO>(options => options.Password = mailSettings.Password);
            services.Configure<MailSettingsDTO>(options => options.Host = mailSettings.Host);
            services.Configure<MailSettingsDTO>(options => options.Port = mailSettings.Port);
            services.Configure<MailSettingsDTO>(options => options.MailImap = mailSettings.MailImap);
            services.Configure<MailSettingsDTO>(options => options.PasswordImap = mailSettings.PasswordImap);
            services.Configure<MailSettingsDTO>(options => options.HostImap = mailSettings.HostImap);
            services.Configure<MailSettingsDTO>(options => options.PortImap = mailSettings.PortImap);

            /**/

            services.Configure<ConnectionStringDTO>(options => options.ConnectionStringCompany = connectionStringCompany);

            /**/

            #region Candidate Repositories & Services DI

            services.AddScoped<IAttachedFileRepository, AttachedFileRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IStudyRepository, StudyRepository>();
            services.AddScoped<ICVRepository, CVRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IUserLinkRepository, UserLinkRepository>();            
            services.AddScoped<ICandidateTechnicalAbilityRepository, CandidateTechnicalAbilityRepository>();
            services.AddScoped<ITechnicalAbilityLevelRepository, TechnicalAbilityLevelRepository>();
            services.AddScoped<ITechnicalAbilityTechnologyRepository, TechnicalAbilityTechnologyRepository>();
            services.AddScoped<IDescriptionRepository, DescriptionRepository>();
            services.AddScoped<IPersonalReferenceRepository, PersonalReferenceRepository>();
            services.AddScoped<IBasicInformationRepository, BasicInformationRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<ICandidateLifePreferenceRepository, CandidateLifePreferenceRepository>();
            services.AddScoped<ILifePreferenceRepository, LifePreferenceRepository>();
            services.AddScoped<ICandidateSoftSkillRepository, CandidateSoftSkillRepository>();
            services.AddScoped<ISoftSkillRepository, SoftSkillRepository>();
            services.AddScoped<ICandidateLanguageOtherRepository, CandidateLanguageOtherRepository>();
            services.AddScoped<ICandidateLanguageRepository, CandidateLanguageRepository>();
            services.AddScoped<ILanguageLevelRepository, LanguageLevelRepository>();
            services.AddScoped<ILanguageOtherRepository, LanguageOtherRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IStudyTypeRepository, StudyTypeRepository>();
            services.AddScoped<ICertificationStateRepository, CertificationStateRepository>();
            services.AddScoped<IStudyAreaRepository, StudyAreaRepository>();
            services.AddScoped<IStudyCertificateRepository, StudyCertificateRepository>();
            services.AddScoped<IRelationTypeRepository, RelationTypeRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();
            services.AddScoped<IEquivalentPositionRepository, EquivalentPositionRepository>();
            services.AddScoped<ICandidateJobPreferenceRepository, CandidateJobPreferenceRepository>();
            services.AddScoped<ICompanyCandidateJobPreferenceRepository, CompanyCandidateJobPreferenceRepository>();
            services.AddScoped<ICompanyRemoteRepository, CompanyRemoteRepository>();
            services.AddScoped<IRecruiteeRemoteRepository, RecruiteeRemoteRepository>();
            services.AddScoped<IFileTypeRepository, FileTypeRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
            services.AddScoped<IStudyStateRepository, StudyStateRepository>();
            services.AddScoped<ICompanyDescriptionRepository, CompanyDescriptionRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IMentionMemberUserRepository, MentionMemberUserRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IRemoteMailRepository, RemoteMailRepository>();
            services.AddScoped<ICCORepository, CCORepository>();
            services.AddScoped<ICCRepository, CCRepository>();
            services.AddScoped<IAttachedFileMailRepository, AttachedFileMailRepository>();
            services.AddScoped<IDocumentCheckRepository, DocumentCheckRepository>();
            services.AddScoped<IDocumentCheckGroupRepository, DocumentCheckGroupRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ICandidateCompanyRepository, CandidateCompanyRepository>();
            services.AddScoped<IRecruiteeCandidateRawRepository, RecruiteeCandidateRawRepository>();
            services.AddScoped<ITimeAvailabilityRepository, TimeAvailabilityRepository>();
            services.AddScoped<IWellnessRepository, WellnessRepository>();
            services.AddScoped<ICandidate_TimeAvailabilityRepository, Candidate_TimeAvailabilityRepository>();
            services.AddScoped<ICandidate_WellnessRepository, Candidate_WellnessRepository>();
            services.AddScoped<ICompany_Candidate_TimeAvailabilityRepository, Company_Candidate_TimeAvailabilityRepository>();
            services.AddScoped<ICompany_Candidate_WellnessRepository, Company_Candidate_WellnessRepository>();
            services.AddScoped<IFileTypeHiringRepository, FileTypeHiringRepository>(); 
            services.AddScoped<ICVHiringRepository, CVHiringRepository>();
            services.AddScoped<IAttachedFileHiringRepository, AttachedFileHiringRepository>();
            services.AddScoped<ICandidate_PostulationRepository, Candidate_PostulationRepository>();
            services.AddScoped<Repositories.ICandidate_TalentGroupRepository, Persistence.Infraestructure.Candidate_TalentGroupRepository>();
            services.AddScoped<Repositories.ICandidate_TagRepository, Persistence.Infraestructure.Candidate_TagRepository>();
            services.AddScoped<Repositories.ICandidate_SourceRepository, Persistence.Infraestructure.Candidate_SourceRepository>();
            services.AddScoped<IAnalyzeCVDataRepository, AnalyzeCVDataRepository>();
            services.AddScoped<ICandidate_BlockReasonRepository, Candidate_BlockReasonRepository>();

            services.AddScoped<IMigrationService, MigrationService>();
            services.AddTransient<IDataRegisterCountService, DataRegisterCountService>();
            services.AddTransient<IAWSS3FileService, AWSS3FileService>();
            services.AddTransient<IDocumentCheckService, DocumentCheckService>();
            services.AddTransient<IAWSCognitoUpdateUserService, AWSCognitoUpdateUserService>();
            services.AddTransient<IStringService, StringService>();
            services.AddTransient<IAuthorizationHelper, AuthorizationHelper>();
            services.AddTransient<IAWSS3BucketHelper, AWSS3BucketHelper>();
            services.AddTransient<IUploadTimeService, UploadTimeService>();
            services.AddTransient<ICvGenerator, CvGenerator>();
            services.AddTransient<IPDFGenerator, PDFGenerator>();
            services.AddTransient<IExcelGenerator, ExcelGenerator>();
            services.AddTransient<ICvService, CvService>();
            services.AddTransient<IStudyService, StudyService>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IMatchServerDate, MatchServerDate>();
            services.AddTransient<IRandomPasswordService, RandomPasswordService>();
            services.AddTransient<IBasicInformationService, BasicInformationService>();
            services.AddTransient<IRemoteMailService, RemoteMailService>();
            services.AddTransient<ICryptoHelper, CryptoHelper>();
            services.AddTransient<IBlockchainService, BlockchainService>();
            services.AddTransient<ICandidate_BlockReasonService, Candidate_BlockReasonService>();
            services.AddTransient<Services.IValidateMethodsService, Services.ValidateMethodsService>();

            #endregion

            #region Company Repositories & Services DI

            services.AddScoped<IActionUserRepository, ActionUserRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<RepositoriesCompany.ICandidate_TalentGroupRepository, Persistence.InfrastructureCompany.Candidate_TalentGroupRepository>();
            services.AddScoped<RepositoriesCompany.ICandidate_SourceRepository, Persistence.InfrastructureCompany.Candidate_SourceRepository>();
            services.AddScoped<RepositoriesCompany.ICandidate_TagRepository, Persistence.InfrastructureCompany.Candidate_TagRepository>();
            services.AddScoped<RepositoriesCompany.ICandidate_SourceRepository, Persistence.InfrastructureCompany.Candidate_SourceRepository>();
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<IDisqualificationReasonRepository, DisqualificationReasonRepository>();
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IEvaluationCriteriaRepository, EvaluationCriteriaRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobProfessionRepository, JobProfessionRepository>();
            services.AddScoped<IMemberUserRepository, MemberUserRepository>();
            services.AddScoped<IPercentCriteriaRepository, PercentCriteriaRepository>();
            services.AddScoped<IPermissionActionUserRepository, PermissionActionUserRepository>();
            services.AddScoped<IPermissionRoleRepository, PermissionRoleRepository>();
            services.AddScoped<IPostulationRepository, PostulationRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ITalentGroupRepository, TalentGroupRepository>();

            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<ICandidate_TalentGroupService, Candidate_TalentGroupService>();
            services.AddTransient<ICandidate_SourceService, Candidate_SourceService>();
            services.AddTransient<ICandidate_TagService, Candidate_TagService>();
            services.AddTransient<ICompanyUserService, CompanyUserService>();
            services.AddTransient<IEvaluationService, EvaluationService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IMatchServerCompanyDateService, MatchServerCompanyDateService>();
            services.AddTransient<IJobProfessionService, JobProfessionService>();
            services.AddTransient<IMemberUserService, MemberUserService>();
            services.AddTransient<IPostulationService, PostulationService>();
            services.AddTransient<IPublicationTimeService, PublicationTimeService>();
            services.AddTransient<ServicesCompany.IValidateMethodsService, ServicesCompany.ValidateMethodsService>();

            #endregion

            services
              .AddAuthentication()
              .AddJwtBearer("candidates", options =>
              {
                  options.SaveToken = true;
                  options.Audience = cognitoConfiguration.CandidateAppClientId;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                      {
                          // Get JsonWebKeySet from AWS
                          HttpClient client = new();
                          var json = client.GetStringAsync(parameters.ValidIssuer + "/.well-known/jwks.json").Result;
                          // Serialize the result
                          return JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
                      },
                      ValidateIssuer = true,
                      ValidIssuer = $"https://cognito-idp.{Region}.amazonaws.com/{cognitoConfiguration.CandidatePoolId}",
                      ValidateLifetime = true,
                      LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                      ValidateAudience = false,
                      ValidAudience = cognitoConfiguration.CandidateAppClientId,
                  };
              })
              .AddJwtBearer("companies", options =>
              {
                  options.SaveToken = true;
                  options.Audience = cognitoConfiguration.CompanyAppClientId;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                      {

                          // Get JsonWebKeySet from AWS
                          HttpClient client = new();
                          var json = client.GetStringAsync(parameters.ValidIssuer + "/.well-known/jwks.json").Result;
                          // Serialize the result
                          return JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
                      },
                      ValidateIssuer = true,
                      ValidIssuer = $"https://cognito-idp.{Region}.amazonaws.com/{cognitoConfiguration.CompanyPoolId}",
                      ValidateLifetime = true,
                      LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                      ValidateAudience = false,
                      ValidAudience = cognitoConfiguration.CompanyAppClientId
                  };
              });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("candidates", "companies")
                    .Build();
            });

            services.AddDbContext<CandidateContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    options => options.EnableRetryOnFailure
                    (
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null
                    ));
            });

            services.AddDbContext<CompanyContext>(options =>
            {
                options.UseNpgsql(connectionStringCompany,
                    options => options.EnableRetryOnFailure
                    (
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null
                    ));
            });

            /* To use AutoMapper */
            services.AddAutoMapper(typeof(CandidateRepository));

            /* Add HTTP Client From Candidates Microservice */
            services.AddHttpClient("Candidates", config =>
            {
                config.BaseAddress = new Uri(candidateURL);
            });

            /* Add HTTP Client From Companies Microservice */
            services.AddHttpClient("Companies", config =>
            {
                config.BaseAddress = new Uri(companyURL);
            });

            /* Add HTTP Client From Recruitee API */
            services.AddHttpClient("Recruitee", config =>
            {
                config.BaseAddress = new Uri(recruiteeURL);
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }                           

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors("MyAllowSpecificOrigins");
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
