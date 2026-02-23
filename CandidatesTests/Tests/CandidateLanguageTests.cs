using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
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
    public class CandidateLanguageTests
    {
        int testSize;
        int index;
        string email;
        string guid;
        int id;

        private IEnumerable<Candidate_Language> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            email = "testpostman@correo.com"; // Mail from candidate in DB
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;

            A.Configure<Candidate_Language>()
                .Fill(x => x.Candidate_LanguageGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                //.Fill(x => x.Email).AsEmailAddress();
                .Fill(x => x.CandidateId, 1)
                .Fill(x => x.LanguageId, 1)
                .Fill(x => x.LanguageLevelId, 1);

            List<Candidate_Language> list = A.ListOf<Candidate_Language>(testSize);

            list[index] = new Candidate_Language
            {
                Candidate_LanguageId = id,
                Candidate_LanguageGuid = guid,
                CandidateId = 1,
                LanguageId = 1,
                LanguageLevelId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_Language> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_Language>> dbSet = new Mock<DbSet<Candidate_Language>>();
            dbSet.As<IQueryable<Candidate_Language>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_Language>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_Language>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_Language>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_Language>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_Language>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_Language>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate_Language>(testData.Provider));

            Type type = typeof(Candidate_Language);
            string colName = "Candidate_LanguageId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_LanguageId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_Language>()))
                 .Callback<Candidate_Language>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_LanguageId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_Language>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddCandidateLanguage()
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
            Candidate_LanguageDTO candidateLanguageDTO = new Candidate_LanguageDTO()
            {
                Candidate_LanguageGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = 1,
                LanguageId = 1,
                LanguageLevelId = 1
            };

            // Create request 
            Candidate_LanguageDTO candidateLanguageDTO2 = new Candidate_LanguageDTO()
            {
                Candidate_LanguageGuid = Convert.ToString(Guid.NewGuid()),
                //CandidateId = 0,
                //LanguageId = 1,
                LanguageLevelId = 1
            };

            CandidateLanguageValidations validator = new CandidateLanguageValidations();
            ValidationResult result1 = validator.Validate(candidateLanguageDTO);
            ValidationResult result2 = validator.Validate(candidateLanguageDTO2);

            Candidate_Language candidateLanguage = mapper.Map<Candidate_LanguageDTO, Candidate_Language>(candidateLanguageDTO);

            CandidateLanguageRepository candidateLanguageRepository = new CandidateLanguageRepository(candidateContext);
            bool created = await candidateLanguageRepository.Add(candidateLanguage);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
            Assert.True(created); // Created successfully
        }

        [Fact]
        public async void AddCandidateLanguageOther()
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
            LanguageOther candidateLanguageDTO = new LanguageOther()
            {
                LanguageOtherGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = 1,
                LanguageOtherId= 1
            };

            LanguageOtherRepository candidateLanguageRepository = new LanguageOtherRepository(candidateContext);
            bool created = await candidateLanguageRepository.Add(candidateLanguageDTO);

            Assert.True(created); // Created successfully
        }

        //[Fact]
        //public async void GetAllCandidatesLanguages()
        //{
        //    System.Diagnostics.Debugger.Launch(); // Debugger

        //    // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
        //    Mock<CandidateContext> mockContext = CreateContext();

        //    // Emulate mapper (IMapper)
        //    MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new MappingTest());
        //    });

        //    IMapper mapper = mapConfig.CreateMapper();

        //    // Instance the Handler cvlass, using the Mocks
        //    CandidateLanguageRepository candidateLanguageRepository = new CandidateLanguageRepository(mockContext.Object);

        //    List<Candidate_Language> candidates = await candidateLanguageRepository.GetAll();

        //    // Tests
        //    Assert.True(candidates.Any()); // True if candidates is not null
        //    Assert.True(candidates.Count == testSize); // Length is equals to the initial value
        //}

        //[Fact]
        //public async void GetCandidatesLanguagesByCandidateEmail()
        //{
        //    System.Diagnostics.Debugger.Launch(); // Debugger

        //    // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
        //    Mock<CandidateContext> mockContext = CreateContext();

        //    // Emulate mapper (IMapper)
        //    MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new MappingTest());
        //    });

        //    IMapper mapper = mapConfig.CreateMapper();

        //    // Instance the Handler cvlass, using the Mocks
        //    CandidateLanguageRepository candidateLanguageRepository = new CandidateLanguageRepository(mockContext.Object);
        //    CandidateLanguageOtherRepository candidateLanguageOtherRepository = new CandidateLanguageOtherRepository(mockContext.Object);

        //    List<Candidate_Language> candidateLanguages = await candidateLanguageRepository.GetByCandidateEmail(email);
        //    List<Candidate_LanguageOther> candidateLanguagesOther = await candidateLanguageOtherRepository.GetByCandidateEmail(email);

        //    // Tests
        //    Assert.True(candidateLanguages != null); // True if candidate is not null
        //    Assert.True(candidateLanguagesOther != null); // True if candidate is not null
        //    //Assert.True(candidate.Email == email);
        //    //Assert.True(candidate.CandidateGuid == guid);
        //}

        [Fact]
        public async void GetCandidateLanguageById()
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
            CandidateLanguageRepository candidateRepository = new CandidateLanguageRepository(mockContext.Object);

            Candidate_Language candidate = await candidateRepository.GetById(id);

            // Tests
            Assert.True(candidate != null); // True if candidate is not null
            Assert.True(candidate.CandidateId == id);
        }

        [Fact]
        public async void EditCandidateLanguage()
        {
            // Create DB in memory
            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            // Create request
            Candidate_Language candidateLanguage = new Candidate_Language()
            {
                Candidate_LanguageId = id,
                Candidate_LanguageGuid = guid,
                CandidateId = 1,
                LanguageLevelId = 1,
                LanguageId = 1
            };

            CandidateLanguageRepository candidateLanguageRepository = new CandidateLanguageRepository(mockContext.Object);
            bool created = await candidateLanguageRepository.Update(candidateLanguage);

            //Assert.True(created); // Created successfully
        }

        //[Fact]
        //public async void GetCandidatesByGuid()
        //{
        //    System.Diagnostics.Debugger.Launch(); // Debugger

        //    // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
        //    Mock<CandidateContext> mockContext = CreateContext();

        //    // Emulate mapper (IMapper)
        //    MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new MappingTest());
        //    });

        //    IMapper mapper = mapConfig.CreateMapper();

        //    // Instance the Handler cvlass, using the Mocks
        //    CandidateLanguageRepository candidateLanguageRepository = new CandidateLanguageRepository(mockContext.Object);

        //    Candidate_Language candidateLanguage = await candidateLanguageRepository.GetByGuid(guid);

        //    // Tests
        //    Assert.True(candidateLanguage != null); // True if candidate is not null
        //    Assert.True(candidateLanguage.Candidate_LanguageGuid == guid);
        //    //Assert.True(candidate.Email == email);
        //}
    }
}
