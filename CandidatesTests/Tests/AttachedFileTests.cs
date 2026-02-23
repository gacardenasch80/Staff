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
    public class AttachedFileTests
    {
        int testSize;
        int index;
        int id;
        string guid;
        Random rnd;

        private IEnumerable<AttachedFile> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            id = 1;
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            rnd = new Random();

            A.Configure<AttachedFile>()
                .Fill(x => x.AttachedFileId, () => { return rnd.Next(3, 100); })
                .Fill(x => x.Name).AsFirstName()
                .Fill(x => x.FileIdentifier).AsPhoneNumber()
                .Fill(x => x.CandidateId, () => { return rnd.Next(3, 100); });

            List<AttachedFile> list = A.ListOf<AttachedFile>(testSize);

            list[index] = new AttachedFile
            {
                AttachedFileId = id,
                Name = "AttachedFiles",
                FileIdentifier = "3216547",
                CandidateId = id
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<AttachedFile> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<AttachedFile>> dbSet = new Mock<DbSet<AttachedFile>>();
            dbSet.As<IQueryable<AttachedFile>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<AttachedFile>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<AttachedFile>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<AttachedFile>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<AttachedFile>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<AttachedFile>(testData.GetEnumerator()));

            dbSet.As<IQueryable<AttachedFile>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<AttachedFile>(testData.Provider));

            Type type = typeof(AttachedFile);
            string colName = "AttachedFileId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "AttachedFileId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<AttachedFile>()))
                 .Callback<AttachedFile>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.AttachedFileId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<AttachedFile>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddAttachedFile()
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
            AttachedFileDTO AttachedFileDTO1 = new AttachedFileDTO()
            {
                Name = "AttachedFiles",
                CandidateId = 2
            };
            

            AttachedFileValidations validator = new AttachedFileValidations();
            ValidationResult result1 = validator.Validate(AttachedFileDTO1);
            //ValidationResult result2 = validator.Validate(AttachedFileDTO2);

            AttachedFile AttachedFile1 = mapper.Map<AttachedFileDTO, AttachedFile>(AttachedFileDTO1);
            //AttachedFile AttachedFile2 = mapper.Map<AttachedFileDTO, AttachedFile>(AttachedFileDTO2);

            AttachedFileRepository attachedFileRepository = new AttachedFileRepository(candidateContext);
            var created = await attachedFileRepository.Add(AttachedFile1);

            Assert.True(created == true); // Meets the validations
            Assert.True(result1.IsValid == true); // Meets the validations
                                                  //Assert.True(basicInfoResponse != null); // Created successfully
        }

        [Fact]
        public async void GetAllAttachedFiles()
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

            // Instance the Handler AttachedFilelass, using the Mocks
            AttachedFileRepository AttachedFileRepository = new AttachedFileRepository(mockContext.Object);

            List<AttachedFile> perRef = await AttachedFileRepository.GetAll();

            // Tests
            Assert.True(perRef.Any()); // True if candidates is not null
            Assert.True(perRef.Count == testSize); // Length is equals to the initial value
        }

        [Fact]
        public async void GetAttachedFileById()
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
            AttachedFileRepository attachedFileRepository = new AttachedFileRepository(mockContext.Object);

            AttachedFile attachedFile = await attachedFileRepository.GetById(id);

            // Tests
            Assert.True(attachedFile != null); // True if basicInfo is not null
            Assert.True(attachedFile.AttachedFileId == id);
        }

        [Fact]
        public async void GetAttachedFileByCandidateId()
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
            AttachedFileRepository AttachedFileRepository = new AttachedFileRepository(mockContext.Object);

            List<AttachedFile> attachedFile = await AttachedFileRepository.GetByCandidateId(id);
            // Tests
            Assert.True(attachedFile != null); // True if basicInfo is not null
        }

        [Fact]
        public void DeleteAttachedFile()
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

            // Instance the Handler AttachedFilelass, using the Mocks
            AttachedFileRepository AttachedFileRepository = new AttachedFileRepository(mockContext.Object);

            AttachedFile AttachedFile = new AttachedFile
            {
                AttachedFileId = id,
                CandidateId = 1,
            };

            var isRemoved = AttachedFileRepository.Remove(AttachedFile.AttachedFileId);


            //Tests
            Assert.True(isRemoved != null); // True if candidate was removed          
        }
    }
}
