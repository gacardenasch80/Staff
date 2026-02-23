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
    public class CandidateJobPreferenceTimeAvailabilityTests
    {
        int testSize;
        int index;
        int id;
        Random rnd;

        private IEnumerable<Candidate_TimeAvailability> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            rnd = new Random();

            A.Configure<Candidate_TimeAvailability>()
                .Fill(x => x.CandidateId, () => { return rnd.Next(1, 29); })
                .Fill(x => x.TimeAvailabilityId, () => { return rnd.Next(1, 29); });

            List<Candidate_TimeAvailability> list = A.ListOf<Candidate_TimeAvailability>(testSize);

            list[index] = new Candidate_TimeAvailability
            {
                Candidate_TimeAvailabilityId = id,
                TimeAvailabilityId = 1,
                CandidateId = id,
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Candidate_TimeAvailability> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Candidate_TimeAvailability>> dbSet = new Mock<DbSet<Candidate_TimeAvailability>>();
            dbSet.As<IQueryable<Candidate_TimeAvailability>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Candidate_TimeAvailability>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Candidate_TimeAvailability>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Candidate_TimeAvailability>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Candidate_TimeAvailability>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Candidate_TimeAvailability>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Candidate_TimeAvailability>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate_TimeAvailability>(testData.Provider));

            Type type = typeof(Candidate_TimeAvailability);
            string colName = "Candidate_TimeAvailabilityId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "Candidate_TimeAvailabilityId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Candidate_TimeAvailability>()))
                 .Callback<Candidate_TimeAvailability>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.Candidate_TimeAvailabilityId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Candidate_TimeAvailability>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddCandidateTimeAvailability()
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

            // Create request
            Candidate_TimeAvailability candidateTimeAvailability = new Candidate_TimeAvailability()
            {
                CandidateId = 1,
                TimeAvailabilityId = 1
            };

            List<Candidate_TimeAvailability> candidateTimeAvailabilityList = new List<Candidate_TimeAvailability>();
            candidateTimeAvailabilityList.Add(candidateTimeAvailability);

            CandidateJobPreferenceRepository candidateJobPreferenceRepository = new CandidateJobPreferenceRepository(candidateContext);
            bool created = await candidateJobPreferenceRepository.AddTimeAvailabilities(candidateTimeAvailabilityList[0].CandidateId, candidateTimeAvailabilityList);

            Assert.True(created); // Created successfully
        }
        
        [Fact]
        public async void GetTimeAvailabilityByCandidateId()
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

            //List<Candidate_TimeAvailability> candidateTimeAvailabilityList = await candidateJobPreferenceRepository.GetTimeAvailabilityByCandidateId(id);

            //// Tests
            //Assert.True(candidateTimeAvailabilityList.Count > 0); // True if candidate is not null
            //Assert.True(candidateTimeAvailabilityList.FirstOrDefault().CandidateId == id);
        }

        [Fact]
        public void DeleteCandidateTimeAvailability()
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

            var deleted = candidateJobPreferenceRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }
    }
}
