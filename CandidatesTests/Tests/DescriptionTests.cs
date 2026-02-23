using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
using CandidatesMS.Models;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesTests.Mapping;
using CandidatesTests.Settings;
using FluentValidation;
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
    public class DescriptionTests
    {
        int testSize;
        int index;
        string text;
        string guid;
        int id;

        private IEnumerable<Description> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            text = "Prueba texto.";
            guid = "00000000-5793-4c53-86bb-c11698938a53";

            A.Configure<Description>()
                .Fill(x => x.DescriptionGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.Text).AsLoremIpsumSentences();

            List<Description> list = A.ListOf<Description>(testSize);

            list[index] = new Description
            {
                Text = text,
                DescriptionGuid = guid,
                DescriptionId = id,
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Description> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Description>> dbSet = new Mock<DbSet<Description>>();
            dbSet.As<IQueryable<Description>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Description>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Description>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Description>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Description>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Description>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Description>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Candidate>(testData.Provider));

            Type type = typeof(Description);
            string colName = "DescriptionId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "DescriptionId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Description>()))
                 .Callback<Description>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.DescriptionId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Description>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddDescription()
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
            Description descriptionDTO1 = new Description()
            {
                DescriptionGuid = Convert.ToString(Guid.NewGuid()),
                Text = "Texto 1",
            };

            // Create request 
            Description descriptionDTO2 = new Description()
            {
                DescriptionGuid = Convert.ToString(Guid.NewGuid()),
                Text = ""
            };

            DescriptionValidations validator = new DescriptionValidations ();
            ValidationResult result1 = validator.Validate(descriptionDTO1);
            ValidationResult result2 = validator.Validate(descriptionDTO2);

            DescriptionRepository descriptionRepository = new DescriptionRepository(candidateContext);
            var created = await descriptionRepository.Add(descriptionDTO1);

            Assert.True(created == true);
            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the description can't be created
            //Assert.True(descriptionResponse != null); // Created successfully
        }

        [Fact]
        public async void EditDescription()
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

            // Create request
            Description descriptionDTO1 = new Description()
            {
                DescriptionGuid = Convert.ToString(Guid.NewGuid()),
                Text = "Texto 1",
                DescriptionId = 1
            };

            // Create request 
            Description descriptionDTO2 = new Description()
            {
                DescriptionGuid = Convert.ToString(Guid.NewGuid()),
                Text = ""
            };

            DescriptionValidations validator = new DescriptionValidations();
            ValidationResult result1 = validator.Validate(descriptionDTO1);
            ValidationResult result2 = validator.Validate(descriptionDTO2);

            DescriptionRepository descriptionRepository = new DescriptionRepository(mockContext.Object);
            var edited = await descriptionRepository.EditDescription(descriptionDTO1);

            Assert.True(edited == true);
            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the description can't be created
            //Assert.True(descriptionResponse != null); // Created successfully
        }

        [Fact]
        public async void GetAllDescriptions()
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
            DescriptionRepository descriptionRepository = new DescriptionRepository(mockContext.Object);

            List<Description> descriptions = await descriptionRepository.GetAll();

            // Tests
            Assert.True(descriptions.Any()); // True if descriptions is not null
            Assert.True(descriptions.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetDescriptionsById()
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
            DescriptionRepository descriptionRepository = new DescriptionRepository(mockContext.Object);

            Description description = await descriptionRepository.GetById(id);

            // Tests
            Assert.True(description != null); // True if candidate is not null
            Assert.True(description.DescriptionId == id);
            //Assert.True(candidate.CandidateGuid == guid);
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
            DescriptionRepository descriptionRepository = new DescriptionRepository(mockContext.Object);

            Description description = await descriptionRepository.GetByGuid(guid);

            // Tests
            Assert.True(description != null); // True if candidate is not null
            Assert.True(description.DescriptionGuid == guid);
        }

        [Fact]
        public void DeleteDescription()
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
            DescriptionRepository DescriptionRepository = new DescriptionRepository(mockContext.Object);

            Description Description = new Description
            {
                DescriptionId = 1,
                DescriptionGuid = "5a2c211e-ae4c-4641-82ef-c25c22973e15",
                CandidateId = 1
            };

            var deleted = DescriptionRepository.Remove(Description.DescriptionId);

            // Tests            
            Assert.True(deleted != null);
        }
    }
}
