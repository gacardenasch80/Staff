using AutoMapper;
using CandidatesMS.Mapping.Validations;
using CandidatesMS.Models;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
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
    public class WorkExperienceTests
    {
        int testSize;
        int index;
        int id;
        string position;
        string company;
        string guid;

        private IEnumerable<WorkExperience> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1; 
            position = "Prueba cargo";
            company = "Prueba companía";
            guid = "00000000-5793-4c53-86bb-c11698938a53";

            A.Configure<WorkExperience>()
                .Fill(x => x.WorkExperienceGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.Position).AsLoremIpsumSentences()
                .Fill(x => x.Company).AsMusicGenreName()
                .Fill(x => x.Authorization, () => { return true; })
                .Fill(x => x.CurrentlyWorking, () => { return false; })
                .Fill(x => x.StartDate, () => { return "08/01/2021"; });

            List<WorkExperience> list = A.ListOf<WorkExperience>(testSize);

            list[index] = new WorkExperience
            {
                WorkExperienceId = id,
                Position = position,
                Company = company,
                Authorization = true,
                CurrentlyWorking = false,
                StartDate = "07/01/2021",
                WorkExperienceGuid = guid,
                CountryName = "Afganistán"
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<WorkExperience> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<WorkExperience>> dbSet = new Mock<DbSet<WorkExperience>>();
            dbSet.As<IQueryable<WorkExperience>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<WorkExperience>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<WorkExperience>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<WorkExperience>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<WorkExperience>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<WorkExperience>(testData.GetEnumerator()));

            dbSet.As<IQueryable<WorkExperience>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate>(testData.Provider));

            Type type = typeof(WorkExperience);
            string colName = "WorkExperienceId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "WorkExperienceId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<WorkExperience>()))
                 .Callback<WorkExperience>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.WorkExperienceId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<WorkExperience>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddWorkExperience()
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
            WorkExperienceDTO workExperienceDTO = new WorkExperienceDTO()
            {
                WorkExperienceGuid = guid,
                Position = "Analista",
                Company = "Apple",
                Authorization = true,
                CurrentlyWorking = false,
                StartDate = "07/01/2021",
                CandidateId = 1,
            };

            WorkExperience workExperience = mapper.Map<WorkExperienceDTO, WorkExperience>(workExperienceDTO); 

            WorkExperienceValidations validator = new WorkExperienceValidations();
            ValidationResult result1 = validator.Validate(workExperienceDTO);

            WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository(candidateContext);
            bool isTrue = await workExperienceRepository.Add(workExperience);

            Assert.True(isTrue == true);
            Assert.True(result1.IsValid == true); // Meets the validations
        }

        [Fact]
        public async void GetAllWorkExperiences()
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
            WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository(mockContext.Object);

            List<WorkExperience> workExperiences = await workExperienceRepository.GetAll();

            // Tests
            Assert.True(workExperiences.Any()); // True if work experience is not null
            Assert.True(workExperiences.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetWorkExperienceById()
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
            WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository(mockContext.Object);

            WorkExperience basicInfo = await workExperienceRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); 
            Assert.True(basicInfo.WorkExperienceId == id);
            Assert.True(basicInfo.CountryName == "Afganistán");
        }

        [Fact]
        public void DeleteWorkExperience()
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
            WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository(mockContext.Object);

            var deleted = workExperienceRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }


        [Fact]
        public async void GetWorkExperiencesByGuid()
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
            WorkExperienceRepository workExperienceRepository = new WorkExperienceRepository(mockContext.Object);

            WorkExperience workExperience = await workExperienceRepository.GetByGuid(guid);

            // Tests
            Assert.True(workExperience != null); // True if candidate is not null
            Assert.True(workExperience.WorkExperienceGuid == guid);
        }
    }
}
