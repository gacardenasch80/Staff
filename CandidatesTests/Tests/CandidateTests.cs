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
using System.Reflection;
using System.Threading;
using Xunit;

namespace CandidatesTests.Tests
{
    public class CandidateTests
    {
        int testSize;
        int index;
        string email;
        string guid;
        int id;

        private IEnumerable<Candidate> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            email = "dacherreragu@gmail.com";
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;

            A.Configure<Candidate>()
                .Fill(x => x.CandidateGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.Email).AsEmailAddress();

            List<Candidate> list = A.ListOf<Candidate>(testSize);

            list[index] = new Candidate
            {
                CandidateId = id,
                Email = email,
                CandidateGuid = guid
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate>> dbSet = new Mock<DbSet<Candidate>>();
            dbSet.As<IQueryable<Candidate>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());
            

            dbSet.As<IAsyncEnumerable<Candidate>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate>(testData.Provider));

            Type type = typeof(Candidate);
            string colName = "CandidateId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "CandidateId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate>()))
                 .Callback<Candidate>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.CandidateId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddCandidate()
        {
            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;
            DbContextOptions<CompanyContext> optionsCompany = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase(databaseName: "CompaniesDB").Options;

            //Create context
            CandidateContext candidateContext = new CandidateContext(options);
            CompanyContext companyContext = new CompanyContext(optionsCompany);

            // Emulate mapper (IMapper) 
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Create request
            CandidateDTO candidateDTO1 = new CandidateDTO()
            {
                CandidateGuid = Convert.ToString(Guid.NewGuid()),
                Email = "test1@test.com"
            };

            // Create request 
            CandidateDTO candidateDTO2 = new CandidateDTO()
            {
                CandidateGuid = Convert.ToString(Guid.NewGuid()),
                Email = ""
            };

            CandidateValidations validator = new CandidateValidations();
            ValidationResult result1 = validator.Validate(candidateDTO1);
            ValidationResult result2 = validator.Validate(candidateDTO2);

            Candidate candidate1 = mapper.Map<CandidateDTO, Candidate>(candidateDTO1);
            Candidate candidate2 = mapper.Map<CandidateDTO, Candidate>(candidateDTO2);

            CandidateRepository candidateRepository = new CandidateRepository(candidateContext, companyContext);
            var created = await candidateRepository.Add(candidate1);

            Assert.True(created == true);
            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
            //Assert.True(candidateResponse != null); // Created successfully
        }

        [Fact]
        public async void GetAllCandidates()
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
            CandidateRepository candidateRepository = new CandidateRepository(mockContext.Object, null);

            List<Candidate> candidates = await candidateRepository.GetAll();

            // Tests
            Assert.True(candidates.Any()); // True if candidates is not null
            Assert.True(candidates.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetCandidatesByEmail()
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
            CandidateRepository candidateRepository = new CandidateRepository(mockContext.Object, null);

            Candidate candidate = await candidateRepository.GetByEmail(email);

            // Tests
            Assert.True(candidate != null); // True if candidate is not null
            Assert.True(candidate.Email == email);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public async void GetCandidatesById()
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
            CandidateRepository candidateRepository = new CandidateRepository(mockContext.Object, null);

            Candidate candidate = await candidateRepository.GetById(id);

            // Tests
            Assert.True(candidate != null); // True if candidate is not null
            Assert.True(candidate.CandidateId == id);
        }

        [Fact]
        public async void GetCandidatesByGuid()
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
            CandidateRepository candidateRepository = new CandidateRepository(mockContext.Object, null);

            Candidate candidate = await candidateRepository.GetByGuid(guid);

            // Tests
            Assert.True(candidate != null); // True if candidate is not null
            Assert.True(candidate.CandidateGuid == guid);
            Assert.True(candidate.Email == email);
        }

        [Fact]
        public void DeleteCandidate()
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
            CandidateRepository CandidateRepository = new CandidateRepository(mockContext.Object, null);

            Candidate candidate = new Candidate
            {
                CandidateId = 1
            };

            var deleted = CandidateRepository.Remove(candidate.CandidateId);

            // Tests            
            Assert.True(deleted != null);
        }

        [Fact]
        public async void EditEditionDate()
        {
            System.Diagnostics.Debugger.Launch(); // Debugger

            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;
            DbContextOptions<CompanyContext> optionsCompany = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase(databaseName: "CompaniesDB").Options;

            //Create context
            CandidateContext candidateContext = new CandidateContext(options);
            CompanyContext companyContext = new CompanyContext(optionsCompany);

            // Emulate mapper (IMapper) 
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            IMapper mapper = mapConfig.CreateMapper();

            // Create request
            CandidateDTO candidateDTO1 = new CandidateDTO()
            {
                CandidateGuid = Convert.ToString(Guid.NewGuid()),
                Email = "test1@test.com"
            };

            // Create request 
            CandidateDTO candidateDTO2 = new CandidateDTO()
            {
                CandidateGuid = Convert.ToString(Guid.NewGuid()),
                Email = ""
            };

            CandidateValidations validator = new CandidateValidations();
            ValidationResult result1 = validator.Validate(candidateDTO1);
            ValidationResult result2 = validator.Validate(candidateDTO2);

            Candidate candidate1 = mapper.Map<CandidateDTO, Candidate>(candidateDTO1);
            Candidate candidate2 = mapper.Map<CandidateDTO, Candidate>(candidateDTO2);

            CandidateRepository candidateRepository = new CandidateRepository(candidateContext, companyContext);
            var created1 = await candidateRepository.Add(candidate1);
            var created2 = await candidateRepository.Add(candidate2);

            string currentDate = DateTime.Now.ToString();

            var isEdited1 = await candidateRepository.EditEditionDate(candidate1.CandidateId);
            var isEdited2 = await candidateRepository.EditEditionDate(candidate2.CandidateId);

            // Tests
            Assert.True(candidate1 != null); // True if candidate is not null
            Assert.True(created1);
            Assert.True(created2);
            Assert.True((bool)isEdited1[0]);
            Assert.True((bool)isEdited2[0]);
        }
    }
}
