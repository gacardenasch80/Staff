using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
using CandidatesMS.Mapping.Validations;
using CandidatesMS.Models;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesTests.Mapping;
using CandidatesTests.Settings;
using FluentValidation.Results;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;


namespace CandidatesTests.Tests
{
    public class BacicInformationTests
    {
        int testSize;
        int index;
        int id;
        string guid;
        Random rnd;

        private IEnumerable<BasicInformation> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            rnd = new Random();

            A.Configure<BasicInformation>()
                .Fill(x => x.BasicInformationGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.Photo, () => { return null; })
                .Fill(X => X.Name).AsFirstName()
                .Fill(X => X.Surname).AsLastName()
                .Fill(X => X.Document).AsPhoneNumber()
                .Fill(X => X.Country).AsCanadianProvince()
                .Fill(X => X.State).AsCanadianProvince()
                .Fill(X => X.City).AsCanadianProvince()
                .Fill(X => X.Address).AsAddress()
                .Fill(X => X.Phone).AsPhoneNumber()
                .Fill(X => X.Cellphone).AsPhoneNumber()
                .Fill(X => X.BirthDate, () => { return "hoy"; })
                .Fill(X => X.LinkedInURL).AsEmailAddressForDomain("linkedin.com")
                .Fill(X => X.FacebookURL).AsEmailAddressForDomain("facebook.com")
                .Fill(X => X.TwitterURL).AsEmailAddressForDomain("twitter.com")
                .Fill(X => X.GitHubURL).AsEmailAddressForDomain("github.com")
                .Fill(X => X.BitBucketURL).AsEmailAddressForDomain("bitbucket.com")
                .Fill(X => X.CandidateId, () => { return rnd.Next(1, 100); })
                .Fill(X => X.DocumentTypeId, () => { return rnd.Next(1, 3); });

            List<BasicInformation> list = A.ListOf<BasicInformation>(testSize);

            list[index] = new BasicInformation
            {
                BasicInformationId = id,
                BasicInformationGuid = guid,
                Photo = null,
                Name = "David",
                Surname = "Herrera",
                Document = "1024",
                Country = "Colombia",
                State = "Bogotá",
                City = "Bogotá",
                Address = "Carrera 9 Este",
                Phone = "760",
                Cellphone = "319",
                BirthDate = "hoy",
                LinkedInURL = "linkedIn.com",
                FacebookURL = "facebook.com",
                TwitterURL = "twitter.com",
                GitHubURL = "github.com",
                BitBucketURL = null,
                CandidateId = 1,
                DocumentTypeId = 2
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<BasicInformation> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<BasicInformation>> dbSet = new Mock<DbSet<BasicInformation>>();
            dbSet.As<IQueryable<BasicInformation>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<BasicInformation>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<BasicInformation>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<BasicInformation>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BasicInformation>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<BasicInformation>(testData.GetEnumerator()));

            dbSet.As<IQueryable<BasicInformation>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<BasicInformation>(testData.Provider));

            Type type = typeof(BasicInformation);
            string colName = "BasicInformationId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "BasicInformationId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<BasicInformation>()))
                 .Callback<BasicInformation>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.BasicInformationId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<BasicInformation>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddBasicInformation()
        {
            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

            //Create context
            CandidateContext candidateContext = new CandidateContext(options);

            // Emulate mapper (IMapper) 
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Create request
            BasicInformationDTO basicInfoDTO1 = new BasicInformationDTO()
            {
                BasicInformationId = 1,
                BasicInformationGuid = guid,
                Photo = null,
                Name = "Leo",
                Surname = "Messi",
                Document = "1025",
                Country = "España",
                State = "Catalonia",
                City = "Barcelona",
                Address = "Carrera 10",
                Phone = "761",
                Cellphone = "320",
                BirthDate = "stringDate",
                LinkedInURL = "linkedIn.com",
                FacebookURL = "facebook.com",
                TwitterURL = "twitter.com",
                GitHubURL = "github.com",
                BitBucketURL = "bitbucket.com",
                CandidateId = 1,
                DocumentTypeId = 2
            };

            // Create request 
            BasicInformationDTO basicInfoDTO2 = new BasicInformationDTO()
            {
                BasicInformationId = 1,
                BasicInformationGuid = guid,
                Photo = null,
                Name = "Pepito",
                Surname = "Perez",
                Document = "1026",
                Country = "Colombia",
                State = "Bogotá",
                City = "Bogotá",
                Address = "Carrera 1",
                Phone = "762",
                Cellphone = "321",
                BirthDate = "hoy",
                LinkedInURL = null,
                FacebookURL = "facebook.com",
                TwitterURL = "twitter.com",
                GitHubURL = "github.com",
                BitBucketURL = null,
                CandidateId = 1,
                DocumentTypeId = 2
            };           

            BasicInformationValidations validator = new BasicInformationValidations();
            ValidationResult result1 = validator.Validate(basicInfoDTO1);
            ValidationResult result2 = validator.Validate(basicInfoDTO2);

            BasicInformation basicInformation1 = mapper.Map<BasicInformationDTO, BasicInformation>(basicInfoDTO1);
            BasicInformation basicInformation2 = mapper.Map<BasicInformationDTO, BasicInformation>(basicInfoDTO2);

            BasicInformationRepository basicInformationRepository = new BasicInformationRepository(candidateContext);
            await basicInformationRepository.Add(basicInformation1);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result1.IsValid == true); // Meets the validations
            //Assert.True(basicInfoResponse != null); // Created successfully
        }

        [Fact]
        public void EditBasicInformation()
        {
            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

            //Create context
            CandidateContext candidateContext = new CandidateContext(options);

            // Emulate mapper (IMapper) 
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Create request
            BasicInformationDTO basicInfoDTO1 = new BasicInformationDTO()
            {
                BasicInformationId = 1,
                BasicInformationGuid = guid,
                Photo = null,
                Name = "Leo",
                Surname = "Messi",
                Document = "1025",
                Country = "España",
                State = "Catalonia",
                City = "Barcelona",
                Address = "Carrera 10",
                Phone = "761",
                Cellphone = "320",
                BirthDate = "stringDate",
                LinkedInURL = "linkedIn.com",
                FacebookURL = "facebook.com",
                TwitterURL = "twitter.com",
                GitHubURL = "github.com",
                BitBucketURL = "bitbucket.com",
                CandidateId = 1,
                DocumentTypeId = 2
            };

            BasicInformation basicInformation1 = mapper.Map<BasicInformationDTO, BasicInformation>(basicInfoDTO1);

            BasicInformationRepository basicInformationRepository = new BasicInformationRepository(candidateContext);
            //bool edited = basicInformationRepository.Update(basicInformation1);

            //Assert.True(edited); // Created successfully
        }

        [Fact]
        public async void GetAllBasicInformations()
        {
            System.Diagnostics.Debugger.Launch(); // Debugger

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            // Emulate mapper (IMapper)
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Instance the Handler cvlass, using the Mocks
            BasicInformationRepository basicInformationRepository = new BasicInformationRepository(mockContext.Object);

            List<BasicInformation> basicInfos = await basicInformationRepository.GetAll();

            // Tests
            Assert.True(basicInfos.Any()); // True if candidates is not null
            Assert.True(basicInfos.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetBasicInformationById()
        {
            System.Diagnostics.Debugger.Launch(); // Debugger

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            // Emulate mapper (IMapper)
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Instance the Handler class, using the Mocks
            BasicInformationRepository basicInformationRepository = new BasicInformationRepository(mockContext.Object);

            BasicInformation basicInfo = await basicInformationRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.BasicInformationId == id);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public async void GetBasicInformationByGuid()
        {
            System.Diagnostics.Debugger.Launch(); // Debugger

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            // Emulate mapper (IMapper)
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Instance the Handler cvlass, using the Mocks
            BasicInformationRepository basicInformationRepository = new BasicInformationRepository(mockContext.Object);

            BasicInformation basicInfo = await basicInformationRepository.GetByGuid(guid);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.BasicInformationGuid == guid);
        }
    }
}
