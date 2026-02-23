using AutoMapper;
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
    public class SocialNetworkTests
    {
        int testSize;
        int index;
        int id;
        Random rnd;

        private IEnumerable<SocialNetwork> ObtainTestData()
        {
            index = 0;
            id = 1;
            testSize = 10;
            rnd = new Random();

            A.Configure<SocialNetwork>()
                .Fill(x => x.SocialNetworkId, () => { return rnd.Next(3, 100); });
                //.Fill(x => x.Name).AsTwitterHandle();

            List<SocialNetwork> list = A.ListOf<SocialNetwork>(testSize);

            list[index] = new SocialNetwork
            {
                SocialNetworkId = id,
                //Name = "TikTok"
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<SocialNetwork> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<SocialNetwork>> dbSet = new Mock<DbSet<SocialNetwork>>();
            dbSet.As<IQueryable<SocialNetwork>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<SocialNetwork>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<SocialNetwork>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<SocialNetwork>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<SocialNetwork>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<SocialNetwork>(testData.GetEnumerator()));

            dbSet.As<IQueryable<SocialNetwork>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<SocialNetwork>(testData.Provider));

            Type type = typeof(SocialNetwork);
            string colName = "SocialNetworkId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "SocialNetworkId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<SocialNetwork>()))
                 .Callback<SocialNetwork>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.SocialNetworkId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<SocialNetwork>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetAllSocialNetworks()
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
            SocialNetworkRepository SocialNetworkRepository = new SocialNetworkRepository(mockContext.Object);

            List<SocialNetwork> socialNetworks = await SocialNetworkRepository.GetAllOrderedById();

            // Tests
            Assert.True(socialNetworks.Any()); // True if candidates is not null
            //Assert.True(socialNetworks[0].Name.Equals("TikTok"));
        }
    }
}
