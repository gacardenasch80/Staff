using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesTests.Mapping;
using CandidatesTests.Settings;
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
    public class CandidateJobPreferenceWellnessTests
    {
        int testSize;
        int index;
        int id;

        private IEnumerable<Candidate_Wellness> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;

            A.Configure<Candidate_Wellness>()
                .Fill(x => x.CandidateId, 1)
                .Fill(x => x.WellnessId, 1);

            List<Candidate_Wellness> list = A.ListOf<Candidate_Wellness>(testSize);

            list[index] = new Candidate_Wellness
            {
                Candidate_WellnessId = id,
                WellnessId = 1,
                CandidateId = id,
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_Wellness> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_Wellness>> dbSet = new Mock<DbSet<Candidate_Wellness>>();
            dbSet.As<IQueryable<Candidate_Wellness>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_Wellness>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_Wellness>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_Wellness>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_Wellness>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_Wellness>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_Wellness>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate_Wellness>(testData.Provider));

            Type type = typeof(Candidate_Wellness);
            string colName = "Candidate_WellnessId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_WellnessId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_Wellness>()))
                 .Callback<Candidate_Wellness>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_WellnessId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_Wellness>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddCandidateWellness()
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

            //IMapper mapper = mapConfig.CreateMapper();

            //// Create request
            //Candidate_LanguageDTO candidateLanguageDTO = new Candidate_LanguageDTO()
            //{
            //    Candidate_LanguageGuid = Convert.ToString(Guid.NewGuid()),
            //    CandidateId = 1,
            //    LanguageId = 1,
            //    LanguageLevelId = 1
            //};

            //// Create request 
            //Candidate_LanguageDTO candidateLanguageDTO2 = new Candidate_LanguageDTO()
            //{
            //    Candidate_LanguageGuid = Convert.ToString(Guid.NewGuid()),
            //    //CandidateId = 0,
            //    //LanguageId = 1,
            //    LanguageLevelId = 1
            //};

            //CandidateLanguageValidations validator = new CandidateLanguageValidations();
            //ValidationResult result1 = validator.Validate(candidateLanguageDTO);
            //ValidationResult result2 = validator.Validate(candidateLanguageDTO2);

            //Candidate_Language candidateLanguage = mapper.Map<Candidate_LanguageDTO, Candidate_Language>(candidateLanguageDTO);

            // Create request
            Candidate_Wellness candidateWellness = new Candidate_Wellness()
            {
                CandidateId = 1,
                WellnessId = 1
            };

            List<Candidate_Wellness> candidateWellnessList = new List<Candidate_Wellness>();
            candidateWellnessList.Add(candidateWellness);

            CandidateJobPreferenceRepository candidateJobPreferenceRepository = new CandidateJobPreferenceRepository(candidateContext);
            bool created = await candidateJobPreferenceRepository.AddWellness(candidateWellnessList[0].CandidateId, candidateWellnessList);

            Assert.True(created); // Created successfully
        }
        
        [Fact]
        public async void GetWellnessByCandidateId()
        {
            System.Diagnostics.Debugger.Launch(); // Debugger

            // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
            Mock<CandidateContext> mockContext = CreateContext();

            // Emulate mapper (IMapper)
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            // Instance the Handler cvlass, using the Mocks
            CandidateJobPreferenceRepository candidateJobPreferenceRepository = new CandidateJobPreferenceRepository(mockContext.Object);

            List<Candidate_Wellness> candidateWellnessList = await candidateJobPreferenceRepository.GetWellnessByCandidateId(id);

            // Tests
            Assert.True(candidateWellnessList.Count > 0); // True if candidate is not null
            Assert.True(candidateWellnessList.FirstOrDefault().CandidateId == id);
        }

        [Fact]
        public void DeleteCandidateWellness()
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
            CandidateJobPreferenceRepository candidateJobPreferenceRepository = new CandidateJobPreferenceRepository(mockContext.Object);

            Candidate_Wellness candidateWellnes = new Candidate_Wellness
            {
                Candidate_WellnessId = id,
                WellnessId = 1,
                CandidateId = id,
            };

            var deleted = candidateJobPreferenceRepository.RemoveWellness(candidateWellnes);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }
    }
}
