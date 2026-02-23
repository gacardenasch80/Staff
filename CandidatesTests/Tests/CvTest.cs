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
    public class CvTest
    {        
        int testSize;
        int index;
        string email;
        string identifier;
        string guid;
        int id;
        Random rnd;

        private IEnumerable<CV> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            email = "dacherreragu@gmail.com";
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            identifier = "124578457845.pdf";
            id = 1;
            rnd = new Random();

            A.Configure<CV>()
                .Fill(x => x.CVGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.CandidateId, () => { return rnd.Next(3, 100); })
                .Fill(x => x.CvIdentifier).AsPhoneNumber();
            //.Fill(x => x.Email).AsEmailAddress();

            List<CV> list = A.ListOf<CV>(testSize);

            list[index] = new CV
            {
                CVId = id,
                CVGuid = guid,
                CandidateId = 1,
                CvIdentifier = identifier
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<CV> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<CV>> dbSet = new Mock<DbSet<CV>>();
            dbSet.As<IQueryable<CV>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<CV>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<CV>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<CV>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<CV>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<CV>(testData.GetEnumerator()));

            dbSet.As<IQueryable<CV>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<CV>(testData.Provider));

            Type type = typeof(CV);
            string colName = "CVId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "CVId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<CV>()))
                 .Callback<CV>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.CVId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<CV>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddCV()
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
            CVDTO CVDTO1 = new CVDTO()
            {
                CandidateId = 1,
                CvIdentifier = identifier
            };

            // Create request 
            CVDTO CVDTO2 = new CVDTO()
            {
                CvIdentifier = identifier
            };

            CVValidations validator = new CVValidations();
            ValidationResult result1 = validator.Validate(CVDTO1);
            ValidationResult result2 = validator.Validate(CVDTO2);

            CV CV1 = mapper.Map<CVDTO, CV>(CVDTO1);
            CV CV2 = mapper.Map<CVDTO, CV>(CVDTO2);

            CVRepository CVRepository = new CVRepository(candidateContext);
            bool created = await CVRepository.Add(CV1);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
            Assert.True(created); // Created successfully
        }

        [Fact]
        public async void GetAllCVs()
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
            CVRepository CVRepository = new CVRepository(mockContext.Object);

            List<CV> CVs = await CVRepository.GetAll();

            // Tests
            Assert.True(CVs.Any()); // True if candidates is not null
            Assert.True(CVs.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetCVById()
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
            CVRepository cvRepository = new CVRepository(mockContext.Object);

            CV cv = await cvRepository.GetById(id);

            // Tests
            Assert.True(cv != null); // True if candidate is not null
            Assert.True(cv.CandidateId == id);
        }


        [Fact]
        public void DeleteCV()
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
            CVRepository CVRepository = new CVRepository(mockContext.Object);

            CV CV = new CV
            {
                CVId = id,
                CVGuid = guid,
                CandidateId = 1,
            };            
            
            var isRemoved = CVRepository.Remove(CV.CVId);


            //Tests
            Assert.True(isRemoved != null); // True if candidate was removed          
        }
    }
}

