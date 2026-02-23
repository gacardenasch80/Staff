using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
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
    public class LifePreferenceTest
    {
        int testSize;
        int index;
        int id;
        string guid;
        Random rnd;

        private IEnumerable<LifePreference> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            rnd = new Random();

            A.Configure<LifePreference>()
                .Fill(x => x.LifePreferenceId, () => { return rnd.Next(3, 100); })
                .Fill(x => x.LifePreferenceGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.LifePreferenceName).AsFirstName();

            List<LifePreference> list = A.ListOf<LifePreference>(testSize);

            list[index] = new LifePreference
            {
                LifePreferenceId = id,
                LifePreferenceGuid = guid,
                LifePreferenceName = "Defoult"
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<LifePreference> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<LifePreference>> dbSet = new Mock<DbSet<LifePreference>>();
            dbSet.As<IQueryable<LifePreference>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<LifePreference>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<LifePreference>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<LifePreference>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LifePreference>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<LifePreference>(testData.GetEnumerator()));

            dbSet.As<IQueryable<LifePreference>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<LifePreference>(testData.Provider));

            Type type = typeof(LifePreference);
            string colName = "LifePreferenceId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "LifePreferenceId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<LifePreference>()))
                 .Callback<LifePreference>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.LifePreferenceId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<LifePreference>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddLifePreference()
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
            LifePreference LifePreference = new LifePreference()
            {
                LifePreferenceId = id,
                LifePreferenceGuid = guid,
                LifePreferenceName = "Defoult"
            };

            LifePreferenceRepository LifePreferenceRepository = new LifePreferenceRepository(candidateContext);
            var created = await LifePreferenceRepository.Add(LifePreference);

            Assert.True(created == true);
        }

        [Fact]
        public async void GetAllLifePreferences()
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
            LifePreferenceRepository lifePreferenceRepository = new LifePreferenceRepository(mockContext.Object);

            List<LifePreference> perRef = await lifePreferenceRepository.GetAll();

            // Tests
            Assert.True(perRef.Any()); // True if candidates is not null
            Assert.True(perRef.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetLifePreferenceById()
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
            LifePreferenceRepository LifePreferenceRepository = new LifePreferenceRepository(mockContext.Object);

            LifePreference basicInfo = await LifePreferenceRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.LifePreferenceId == id);
        }

        //[Fact]
        //public void DeleteLifePreference()
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

        //    // Instance the Handler class, using the Mocks
        //    LifePreferenceRepository LifePreferenceRepository = new LifePreferenceRepository(mockContext.Object);

        //    var deleted = LifePreferenceRepository.Remove(id);

        //    // Tests
        //    //Assert.True(deleted != null); // True if basicInfo is not null
        //    Assert.True(deleted != null);
        //    //Assert.True(candidate.CandidateGuid == guid);
        //}
        
    }
}
