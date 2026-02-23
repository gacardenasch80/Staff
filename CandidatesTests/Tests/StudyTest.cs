using AutoMapper;
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
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CandidatesTests.Tests
{
    public class StudyTest
    {
        int testSize;
        int index;
        int id;
        string guid;
        Random rnd;
        private Study studyId;

        private IEnumerable<Study> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            rnd = new Random();

            A.Configure<Study>()
                .Fill(x => x.Institution).AsCanadianProvince()
                .Fill(x => x.TitleId, () => { return rnd.Next(1, 4); })
                .Fill(x => x.StudyTypeId, () => { return rnd.Next(1, 4); })
                .Fill(x => x.CertificationStateId, () => { return rnd.Next(1, 4); })
                .Fill(X => X.StudyAreaId, () => { return rnd.Next(1, 4); })
                .Fill(X => X.IsStudying, () => { return false; })
                .Fill(x => x.StartDate).AsPhoneNumber()
                .Fill(x => x.EndDate).AsPhoneNumber()
                .Fill(x => x.CandidateId, () => { return rnd.Next(3, 100); });

            List<Study> list = A.ListOf<Study>(testSize);

            list[index] = new Study
            {
                StudyId = 1,
                Institution = "David",
                TitleId = 1,
                StudyTypeId = 1,
                CertificationStateId = 1,
                StudyAreaId = 1,
                IsStudying = false,
                StartDate = "32154",
                EndDate = "32154",
                CandidateId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Study> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Study>> dbSet = new Mock<DbSet<Study>>();
            dbSet.As<IQueryable<Study>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Study>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Study>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Study>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Study>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Study>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Study>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Study>(testData.Provider));

            Type type = typeof(Study);
            string colName = "StudyId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "StudyId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Update(It.IsAny<Study>()))
                    .Returns<Study>(entity =>
                     dbSet.Object.Update(entity));

                dbSet.Setup(x => x.Remove(It.IsAny<Study>()))
                 .Callback<Study>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids => 
                    await dbSet.Object.FirstOrDefaultAsync( b => b.StudyId == (int)ids[0]));
            }

            DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
                .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

            Mock<CandidateContext> context = new Mock<CandidateContext>(options);
            //context.Setup(t => t.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(testData));
            context.Setup(x => x.Set<Study>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddStudy()
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
            StudyDTO StudyDTO1 = new StudyDTO()
            {
                Institution = "David",
                TitleId = 1,
                StudyTypeId = 2,
                CertificationStateId = 2,
                StudyAreaId = 2,
                IsStudying = false,
                StartDate = "32154",
                EndDate = "32154",
                CandidateId = 1
            };

            // Create request 
            StudyDTO StudyDTO2 = new StudyDTO()
            {
                Institution = "David",
                TitleId = 1,
                StudyTypeId = 2,
                CertificationStateId = 2,
                StudyAreaId = 2,
                IsStudying = false,
                StartDate = "32154",
                EndDate = "32154"
            };

            StudyValidations validator = new StudyValidations();
            ValidationResult result1 = validator.Validate(StudyDTO1);
            ValidationResult result2 = validator.Validate(StudyDTO2);

            Study Study1 = mapper.Map<StudyDTO, Study>(StudyDTO1);
            //Study Study2 = mapper.Map<StudyDTO, Study>(StudyDTO2);

            StudyRepository StudyRepository = new StudyRepository(candidateContext);
            await StudyRepository.Add(Study1);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // Meets the validations
                                                  //Assert.True(basicInfoResponse != null); // Created successfully
        }

        //[Fact]
        //public async void EditStudy()
        //{
        //    System.Diagnostics.Debugger.Launch(); // Debugger
        //    // Create DB in memory

        //    //DbContextOptions<CandidateContext> options = new DbContextOptionsBuilder<CandidateContext>()
        //    //    .UseInMemoryDatabase(databaseName: "CandidatesDB").Options;

        //    //Create context
        //    //CandidateContext candidateContext = new CandidateContext(options);


        //    // Emulate EntityFrameWorkCore Instance (Context) -> Mocks
        //    Mock<CandidateContext> mockContext = CreateContext();


        //    // Emulate mapper (IMapper) 
        //    MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new MappingTest());
        //    });

        //    IMapper mapper = mapConfig.CreateMapper();

        //    // Create request
        //    StudyDTO StudyDTO1 = new StudyDTO()
        //    {
        //        StudyId = 1,
        //        Institution = "David",
        //        TitleId = 2,
        //        StudyTypeId = 2,
        //        CertificationStateId = 2,
        //        StudyAreaId = 2,
        //        IsStudying = false,
        //        StartDate = "32154",
        //        EndDate = "32154",
        //        CandidateId = 1
        //    };

        //    // Create request 
        //    StudyDTO StudyDTO2 = new StudyDTO()
        //    {
        //        Institution = "David",
        //        TitleId = 1,
        //        StudyTypeId = 2,
        //        CertificationStateId = 2,
        //        StudyAreaId = 2,
        //        IsStudying = false,
        //        StartDate = "32154",
        //        EndDate = "32154"
        //    };

        //    StudyValidations validator = new StudyValidations();
        //    ValidationResult result1 = validator.Validate(StudyDTO1);
        //    ValidationResult result2 = validator.Validate(StudyDTO2);

        //    Study Study1 = mapper.Map<StudyDTO, Study>(StudyDTO1);
        //    //Study Study2 = mapper.Map<StudyDTO, Study>(StudyDTO2);

        //    StudyRepository studyRepository = new StudyRepository(mockContext.Object);
        //    var updated = await studyRepository.Update(Study1);

        //    Study basicInfo = await studyRepository.GetById(id);

        //    Assert.True(basicInfo.StudyTypeId == Study1.StudyTypeId); // Meets the validations
        //    Assert.True(result1.IsValid == true); // Meets the validations
        //    Assert.True(result2.IsValid == false); // Meets the validations
        //                                          //Assert.True(basicInfoResponse != null); // Created successfully
        //}

        [Fact]
        public async void GetAllStudys()
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
            StudyRepository StudyRepository = new StudyRepository(mockContext.Object);

            List<Study> perRef = await StudyRepository.GetAll();

            // Tests
            Assert.True(perRef.Any()); // True if candidates is not null
            Assert.True(perRef.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetStudyById()
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
            StudyRepository StudyRepository = new StudyRepository(mockContext.Object);

            Study basicInfo = await StudyRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.StudyId == id);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public void DeleteStudy()
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
            StudyRepository StudyRepository = new StudyRepository(mockContext.Object);

            Study study = new Study
            {
                StudyId = 1,
                Institution = "David",
                TitleId = 1,
                StudyTypeId = 2,
                CertificationStateId = 2,
                StudyAreaId = 2,
                IsStudying = false,
                StartDate = "32154",
                EndDate = "32154",
                CandidateId = 1
            };

            var deleted = StudyRepository.Remove(study.StudyId);

            // Tests            
            Assert.True(deleted != null);            
        }

        [Fact]
        public async void GetStudyByCandidateId()
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
            StudyRepository StudyRepository = new StudyRepository(mockContext.Object);

            List<Study> perReferences = await StudyRepository.GetByCandidateId(id);
            // Tests
            Assert.True(perReferences != null); // True if basicInfo is not null
        }
    }
}
