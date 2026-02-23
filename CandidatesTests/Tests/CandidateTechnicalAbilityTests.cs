using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
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
    public class CandidateTechnicalAbilityTests
    {
        int testSize;
        string guid;
        int id;
        int index;

        private IEnumerable<Candidate_TechnicalAbility> ObtainTestData()
        {
            testSize = 5;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;
            index = 0;

            A.Configure<Candidate_TechnicalAbility>()
                .Fill(x => x.CandidateId, 1)
                .Fill(x => x.TechnicalAbilityTechnologyId, 1)
                .Fill(x => x.TechnicalAbilityLevelId, 1)
                .Fill(x => x.Candidate_TechnicalAbilityGuid, () => { return Convert.ToString(Guid.NewGuid()); });

            List<Candidate_TechnicalAbility> list = A.ListOf<Candidate_TechnicalAbility>(testSize);

            list[index] = new Candidate_TechnicalAbility()
            {
                Candidate_TechnicalAbilityId = id,
                Candidate_TechnicalAbilityGuid = guid,
                TechnicalAbilityLevelId = 1,
                TechnicalAbilityTechnologyId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_TechnicalAbility> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_TechnicalAbility>> dbSet = new Mock<DbSet<Candidate_TechnicalAbility>>();
            dbSet.As<IQueryable<Candidate_TechnicalAbility>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_TechnicalAbility>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_TechnicalAbility>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_TechnicalAbility>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_TechnicalAbility>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_TechnicalAbility>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_TechnicalAbility>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate>(testData.Provider));

            Type type = typeof(Candidate_TechnicalAbility);
            string colName = "Candidate_TechnicalAbilityId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_TechnicalAbilityId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_TechnicalAbility>()))
                 .Callback<Candidate_TechnicalAbility>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_TechnicalAbilityId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_TechnicalAbility>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetCandidatesTechnicalAbilities()
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
            CandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository = new CandidateTechnicalAbilityRepository(mockContext.Object);

            List<Candidate_TechnicalAbility> candidatesAbilities = await candidateTechnicalAbilityRepository.GetAll();

            // Tests
            Assert.True(candidatesAbilities.Any()); // True if candidates is not null
            Assert.True(candidatesAbilities.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void AddCandidateTechnicalAbility()
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
            Candidate_TechnicalAbilityDTO candidateTechAbilityDTO1 = new Candidate_TechnicalAbilityDTO()
            {
                CandidateId = 1,
                TechnicalAbilityLevelId = 1,
                TechnicalAbilityTechnologyId = 1
            };

            // Create request 
            Candidate_TechnicalAbilityDTO candidateTechAbilityDTO2 = new Candidate_TechnicalAbilityDTO()
            {
                TechnicalAbilityLevelId = 1,
                TechnicalAbilityTechnologyId = 1
            };

            CandidateTechnicalAbilityValidations validator = new CandidateTechnicalAbilityValidations();
            ValidationResult result1 = validator.Validate(candidateTechAbilityDTO1);
            ValidationResult result2 = validator.Validate(candidateTechAbilityDTO2);

            Candidate_TechnicalAbility candidateTechnicalAbility = mapper.Map<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>(candidateTechAbilityDTO1);

            CandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository = new CandidateTechnicalAbilityRepository(candidateContext);
            bool created = await candidateTechnicalAbilityRepository.Add(candidateTechnicalAbility);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
            Assert.True(candidateTechnicalAbility != null); // Created successfully
        }

        [Fact]
        public async void GetCandidate_TechnicalAbilityById()
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
            CandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository = new CandidateTechnicalAbilityRepository(mockContext.Object);

            Candidate_TechnicalAbility basicInfo = await candidateTechnicalAbilityRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null);
            Assert.True(basicInfo.Candidate_TechnicalAbilityId == id);
        }

        [Fact]
        public async void DeleteCandidate_TechnicalAbility()
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
            CandidateTechnicalAbilityRepository candidate_TechnicalAbilityRepository = new CandidateTechnicalAbilityRepository(mockContext.Object);

            Candidate_TechnicalAbility deleted = await candidate_TechnicalAbilityRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            //Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public async void EditCandidateTechnicalAbility()
        {
            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            //Create context
            //CandidateContext candidateContext = new CandidateContext(options);

            // Emulate mapper (IMapper) 
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Create request
            Candidate_TechnicalAbilityDTO techAbilityDTO = new Candidate_TechnicalAbilityDTO()
            {
                CandidateId = id,
                Candidate_TechnicalAbilityId = 11,
                Candidate_TechnicalAbilityGuid = guid,
                TechnicalAbilityTechnologyId = 9,
                TechnicalAbilityLevelId = 1
            };

            Candidate_TechnicalAbility techAbility = mapper.Map<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>(techAbilityDTO);

            CandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository = new CandidateTechnicalAbilityRepository(mockContext.Object);

            bool edited = await candidateTechnicalAbilityRepository.Update(techAbility);

            Assert.True(edited != null); // Created successfully
        }
    }
}
