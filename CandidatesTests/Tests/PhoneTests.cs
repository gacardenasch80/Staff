using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesTests.Mapping;
using CandidatesTests.Settings;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace CandidatesTests.Tests
{
    public class PhoneTests
    {
        int testSize;
        int index;
        int id;
        int basicInformationId;
        Random rnd;

        private IEnumerable<Phone> ObtainTestData()
        {
            index = 0;
            id = 1;
            basicInformationId = 1;
            testSize = 10;
            rnd = new Random();

            A.Configure<Phone>()
                .Fill(x => x.PhoneId, () => { return rnd.Next(3, 100); })
                .Fill(x => x.Number).AsPhoneNumber()
                .Fill(x => x.BasicInformationId, () => { return rnd.Next(1, 100); });

            List<Phone> list = A.ListOf<Phone>(testSize);

            list[index] = new Phone
            {
                PhoneId = id,
                Number = "3194534534",
                BasicInformationId = basicInformationId
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Phone> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Phone>> dbSet = new Mock<DbSet<Phone>>();
            dbSet.As<IQueryable<Phone>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Phone>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Phone>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Phone>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Phone>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Phone>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Phone>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Phone>(testData.Provider));

            Type type = typeof(Phone);
            string colName = "PhonekId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "PhoneId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Phone>()))
                 .Callback<Phone>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.PhoneId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Phone>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetAllPhonesByBasicInformationId()
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
            PhoneRepository PhoneRepository = new PhoneRepository(mockContext.Object);

            List<Phone> phones = await PhoneRepository.GetByBasicInformationId(basicInformationId);

            // Tests
            Assert.True(phones.Any()); // True if candidates is not null
        }

        [Fact]
        public async void AddPhone()
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
            PhoneDTO PhoneDTO1 = new PhoneDTO()
            {
                Number = "Phone",
                BasicInformationId = 1,
                PhoneId = 2
            };

            Phone Phone1 = mapper.Map<PhoneDTO, Phone>(PhoneDTO1);

            PhoneRepository phoneRepository = new PhoneRepository(candidateContext);
            var created = await phoneRepository.Add(Phone1);

            Assert.True(created == true); // Meets the validations
        }

        [Fact]
        public void DeletePhone()
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
            PhoneRepository PhoneRepository = new PhoneRepository(mockContext.Object);

            Phone Phone = new Phone
            {
                PhoneId = id,
                BasicInformationId = 1,
            };

            var isRemoved = PhoneRepository.Remove(Phone.PhoneId);


            //Tests
            Assert.True(isRemoved != null); // True if candidate was removed          
        }
    }
}
