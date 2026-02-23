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
    public class CandidateLifePrefereneTests
    {
        int testSize;
        int index;
        string guid;
        int id;
        Random rnd;

        private IEnumerable<Candidate_LifePreference> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;
            rnd = new Random();

            A.Configure<Candidate_LifePreference>()
                .Fill(x => x.Candidate_LifePreferenceGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.CandidateId, () => { return rnd.Next(5, 100); })
                .Fill(x => x.OtherLifePreference).AsLoremIpsumSentences()
                .Fill(x => x.LifePreferenceId, () => { return rnd.Next(1, 29); });

            List<Candidate_LifePreference> list = A.ListOf<Candidate_LifePreference>(testSize);

            list[index] = new Candidate_LifePreference
            {
                Candidate_LifePreferenceId = id,
                Candidate_LifePreferenceGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = id,
                LifePreferenceId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_LifePreference> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_LifePreference>> dbSet = new Mock<DbSet<Candidate_LifePreference>>();
            dbSet.As<IQueryable<Candidate_LifePreference>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_LifePreference>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_LifePreference>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_LifePreference>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_LifePreference>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_LifePreference>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_LifePreference>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate_LifePreference>(testData.Provider));

            Type type = typeof(Candidate_LifePreference);
            string colName = "Candidate_LifePreferenceId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_LifePreferenceId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_LifePreference>()))
                 .Callback<Candidate_LifePreference>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_LifePreferenceId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_LifePreference>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetAllCandidateLifePreferences()
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
            CandidateLifePreferenceRepository candidateLifePreferenceRepository = new CandidateLifePreferenceRepository(mockContext.Object);

            List<Candidate_LifePreference> lifePreferences = await candidateLifePreferenceRepository.GetAll();

            // Tests
            Assert.True(lifePreferences.Any()); // True if candidates is not null
            Assert.True(lifePreferences.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void AddCandidateLifePreference()
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
            Candidate_LifePreferenceDTO candidateLifePreferenceDTO = new Candidate_LifePreferenceDTO()
            {
                Candidate_LifePreferenceGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = 1,
                LifePreferenceId = 1,
            };

            Candidate_LifePreference candidateLifePreference = mapper.Map<Candidate_LifePreferenceDTO, Candidate_LifePreference>(candidateLifePreferenceDTO);

            CandidateLifePreferenceRepository candidateLifePreferenceRepository = new CandidateLifePreferenceRepository(candidateContext);
            bool created = await candidateLifePreferenceRepository.Add(candidateLifePreference);

            //Assert.True(result1.IsValid == true); // Meets the validations
            //Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
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

        //    List<Candidate_LifePreference> candidates = await candidateLanguageRepository.GetAll();

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

        //    List<Candidate_LifePreference> candidateLanguages = await candidateLanguageRepository.GetByCandidateEmail(email);
        //    List<Candidate_LifePreferenceOther> candidateLanguagesOther = await candidateLanguageOtherRepository.GetByCandidateEmail(email);

        //    // Tests
        //    Assert.True(candidateLanguages != null); // True if candidate is not null
        //    Assert.True(candidateLanguagesOther != null); // True if candidate is not null
        //    //Assert.True(candidate.Email == email);
        //    //Assert.True(candidate.CandidateGuid == guid);
        //}

        [Fact]
        public async void GetCandidateLifePreferenceById()
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
            CandidateLifePreferenceRepository candidateLifePreferenceRepository = new CandidateLifePreferenceRepository(mockContext.Object);

            Candidate_LifePreference candidateLifePreference = await candidateLifePreferenceRepository.GetById(id);

            // Tests
            Assert.True(candidateLifePreference != null); // True if candidate is not null
            //Assert.True(candidateLifePreference.CandidateId == id);
        }


        [Fact]
        public async void GetCandidateLifePreferenceByCandidateId()
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
            CandidateLifePreferenceRepository candidateLifePreferenceRepository = new CandidateLifePreferenceRepository(mockContext.Object);

            List<Candidate_LifePreference> candidateLifePreferences = await candidateLifePreferenceRepository.GetByCandidateId(id, true);
            List<Candidate_LifePreference> companyCandidateLifePreferences = await candidateLifePreferenceRepository.GetByCandidateId(id, false);

            // Tests
            Assert.True(candidateLifePreferences != null); // True if basicInfo is not null
            Assert.True(companyCandidateLifePreferences != null); // True if basicInfo is not null
        }

        [Fact]
        public void DeleteCandidateLifePreference()
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
            CandidateLifePreferenceRepository candidateLifePreferenceRepository = new CandidateLifePreferenceRepository(mockContext.Object);

            var deleted = candidateLifePreferenceRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }
    }
}
