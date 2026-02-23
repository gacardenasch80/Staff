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
using System.Threading;
using Xunit;

namespace CandidatesTests.Tests
{
    public class PersonalReferenceTest
    { 
        int testSize;
        int index;
        int id;
        string guid;
        Random rnd;

        private IEnumerable<PersonalReference> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            rnd = new Random();

            A.Configure<PersonalReference>()
                .Fill(x => x.ReferenceName).AsFirstName()
                .Fill(x => x.ReferenceSurname).AsFirstName()
                .Fill(x => x.PhoneNumber).AsPhoneNumber()
                .Fill(x => x.AditionalNumber).AsPhoneNumber()
                .Fill(X => X.Country).AsCanadianProvince()
                .Fill(X => X.State).AsCanadianProvince()
                .Fill(x => x.City).AsCanadianProvince()
                .Fill(x => x.CandidateId, () => { return rnd.Next(3, 100); })
                .Fill(X => X.RelationTypeId, () => { return rnd.Next(1, 2); });

            List<PersonalReference> list = A.ListOf<PersonalReference>(testSize);

            list[index] = new PersonalReference
            {
                PersonalReferenceId = 1,
                ReferenceName = "David",
                ReferenceSurname = "Herrera",
                PhoneNumber = "321654",
                AditionalNumber = "65487",
                Country = "Colombia",
                State = "Bogotá",
                City = "Bogotá",
                CandidateId = id,
                RelationTypeId = 1
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<PersonalReference> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<PersonalReference>> dbSet = new Mock<DbSet<PersonalReference>>();
            dbSet.As<IQueryable<PersonalReference>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<PersonalReference>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<PersonalReference>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<PersonalReference>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<PersonalReference>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<PersonalReference>(testData.GetEnumerator()));

            dbSet.As<IQueryable<PersonalReference>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<PersonalReference>(testData.Provider));

            Type type = typeof(PersonalReference);
            string colName = "PersonalReferenceId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "PersonalReferenceId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<PersonalReference>()))
                 .Callback<PersonalReference>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.PersonalReferenceId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<PersonalReference>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddPersonalReference()
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
            PersonalReferenceDTO personalReferenceDTO1 = new PersonalReferenceDTO()
            {
                ReferenceName = "David",
                ReferenceSurname = "Herrera",
                PhoneNumber = "321654",
                AditionalNumber = "65487",
                Country = "Colombia",
                State = "Bogotá",
                City = "Bogotá",
                CandidateId = 2,
                RelationTypeId = 1
            };

            // Create request 
            PersonalReferenceDTO personalReferenceDTO2 = new PersonalReferenceDTO()
            {
                ReferenceName = "David",
                ReferenceSurname = "Herrera",
                PhoneNumber = "321654",
                AditionalNumber = "65487",
                Country = "Colombia",
                State = "Bogotá",
                City = "Bogotá",
                CandidateId = 2,
                RelationTypeId = 1
            };

            PersonalReferenceValidations validator = new PersonalReferenceValidations();
            ValidationResult result1 = validator.Validate(personalReferenceDTO1);
            ValidationResult result2 = validator.Validate(personalReferenceDTO2);

            PersonalReference PersonalReference1 = mapper.Map<PersonalReferenceDTO, PersonalReference>(personalReferenceDTO1);
            PersonalReference PersonalReference2 = mapper.Map<PersonalReferenceDTO, PersonalReference>(personalReferenceDTO2);

            PersonalReferenceRepository PersonalReferenceRepository = new PersonalReferenceRepository(candidateContext);
            await PersonalReferenceRepository.Add(PersonalReference1);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result1.IsValid == true); // Meets the validations
                                                  //Assert.True(basicInfoResponse != null); // Created successfully
        }

        [Fact]
        public async void GetAllPersonalReferences()
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
            PersonalReferenceRepository PersonalReferenceRepository = new PersonalReferenceRepository(mockContext.Object);

            List<PersonalReference> perRef = await PersonalReferenceRepository.GetAll();

            // Tests
            Assert.True(perRef.Any()); // True if candidates is not null
            Assert.True(perRef.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetPersonalReferenceById()
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
            PersonalReferenceRepository PersonalReferenceRepository = new PersonalReferenceRepository(mockContext.Object);

            PersonalReference basicInfo = await PersonalReferenceRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.PersonalReferenceId == id);        
        }

        [Fact]
        public void DeletePersonalReference()
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
            PersonalReferenceRepository personalReferenceRepository = new PersonalReferenceRepository(mockContext.Object);

            var deleted = personalReferenceRepository.Remove(id);

            // Tests
            //Assert.True(deleted != null); // True if basicInfo is not null
            Assert.True(deleted != null);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public async void GetPersonalReferenceByCandidateId()
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
            PersonalReferenceRepository PersonalReferenceRepository = new PersonalReferenceRepository(mockContext.Object);

            List<PersonalReference> perReferences = await PersonalReferenceRepository.GetByCandidateId(id);
            // Tests
            Assert.True(perReferences != null); // True if basicInfo is not null
        }
    }
}
