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
    public class CandidateSoftSkillTests
    {
        int testSize;
        int index;
        string guid;
        int id;
        Random rnd;

        private IEnumerable<Candidate_SoftSkill> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;
            rnd = new Random();

            A.Configure<Candidate_SoftSkill>()
                .Fill(x => x.Candidate_SoftSkillGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.CandidateId, () => { return rnd.Next(5, 100); })
                .Fill(x => x.Description).AsLoremIpsumSentences()
                .Fill(x => x.SoftSkillId, () => { return rnd.Next(1, 29); });

            List<Candidate_SoftSkill> list = A.ListOf<Candidate_SoftSkill>(testSize);

            list[index] = new Candidate_SoftSkill
            {
                Candidate_SoftSkillId = id,
                Candidate_SoftSkillGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = id,
                SoftSkillId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_SoftSkill> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_SoftSkill>> dbSet = new Mock<DbSet<Candidate_SoftSkill>>();
            dbSet.As<IQueryable<Candidate_SoftSkill>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_SoftSkill>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_SoftSkill>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_SoftSkill>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_SoftSkill>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_SoftSkill>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_SoftSkill>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate_SoftSkill>(testData.Provider));

            Type type = typeof(Candidate_SoftSkill);
            string colName = "Candidate_SoftSkillId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_SoftSkillId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_SoftSkill>()))
                 .Callback<Candidate_SoftSkill>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_SoftSkillId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_SoftSkill>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetAllCandidateSoftSkill()
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
            CandidateSoftSkillRepository personalReferenceRepository = new CandidateSoftSkillRepository(mockContext.Object);

            List<Candidate_SoftSkill> softSkills = await personalReferenceRepository.GetAll();

            // Tests
            Assert.True(softSkills.Any()); // True if candidates is not null
            Assert.True(softSkills.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void AddCandidateSoftSkill()
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
            Candidate_SoftSkillDTO candidateSoftSkillDTO = new Candidate_SoftSkillDTO()
            {
                Candidate_SoftSkillGuid = Convert.ToString(Guid.NewGuid()),
                CandidateId = 1,
                SoftSkillId = 1,
            };

            Candidate_SoftSkill candidateSoftSkill = mapper.Map<Candidate_SoftSkillDTO, Candidate_SoftSkill>(candidateSoftSkillDTO);

            CandidateSoftSkillRepository candidateSoftSkillRepository = new CandidateSoftSkillRepository(candidateContext);
            bool created = await candidateSoftSkillRepository.Add(candidateSoftSkill);

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

        //    List<Candidate_SoftSkill> candidates = await candidateLanguageRepository.GetAll();

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

        //    List<Candidate_SoftSkill> candidateLanguages = await candidateLanguageRepository.GetByCandidateEmail(email);
        //    List<Candidate_SoftSkillOther> candidateLanguagesOther = await candidateLanguageOtherRepository.GetByCandidateEmail(email);

        //    // Tests
        //    Assert.True(candidateLanguages != null); // True if candidate is not null
        //    Assert.True(candidateLanguagesOther != null); // True if candidate is not null
        //    //Assert.True(candidate.Email == email);
        //    //Assert.True(candidate.CandidateGuid == guid);
        //}

        [Fact]
        public async void GetCandidateSoftSkillById()
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
            CandidateSoftSkillRepository candidateSoftSkillRepository = new CandidateSoftSkillRepository(mockContext.Object);

            Candidate_SoftSkill candidateSoftSkill = await candidateSoftSkillRepository.GetById(id);

            // Tests
            Assert.True(candidateSoftSkill != null); // True if candidate is not null
            Assert.True(candidateSoftSkill.CandidateId == id);
        }


        [Fact]
        public async void GetCandidateSoftSkillByCandidateId()
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
            CandidateSoftSkillRepository candidateSoftSkillRepository = new CandidateSoftSkillRepository(mockContext.Object);

            List<Candidate_SoftSkill> softSkill = await candidateSoftSkillRepository.GetByCandidateId(id);
            // Tests
            Assert.True(softSkill != null); // True if basicInfo is not null
        }

        [Fact]
        public void DeleteCandidateSoftSkill()
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
            CandidateSoftSkillRepository candidateSoftSkillRepository = new CandidateSoftSkillRepository(mockContext.Object);

            var deleted = candidateSoftSkillRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
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

        //    Candidate_SoftSkill candidateLanguage = await candidateLanguageRepository.GetByGuid(guid);

        //    // Tests
        //    Assert.True(candidateLanguage != null); // True if candidate is not null
        //    Assert.True(candidateLanguage.Candidate_SoftSkillGuid == guid);
        //    //Assert.True(candidate.Email == email);
        //}
    }
}
