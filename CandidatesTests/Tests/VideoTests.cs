using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Mapping;
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
    public class VideoTests
    {
        int testSize;
        int index;
        string email;
        string guid;
        int id;

        private IEnumerable<Video> ObtainTestData()
        {
            testSize = 10;
            index = 0;
            email = "dacherreragu@gmail.com";
            guid = "00000000-5793-4c53-86bb-c11698938a53";
            id = 1;

            A.Configure<Video>()
                .Fill(x => x.VideoGuid, () => { return Convert.ToString(Guid.NewGuid()); })
                .Fill(x => x.CandidateId, 1)
                .Fill(x => x.IsUrl, true);
                //.Fill(x => x.Email).AsEmailAddress();

            List<Video> list = A.ListOf<Video>(testSize);

            list[index] = new Video
            {
                VideoId = id,
                VideoGuid = guid,
                CandidateId = 1,
                IsUrl = false
            };

            return list;
        }

        private Mock<CandidateContext> CreateContext()
        {
            IQueryable<Video> testData = ObtainTestData().AsQueryable();

            Mock<DbSet<Video>> dbSet = new Mock<DbSet<Video>>();
            dbSet.As<IQueryable<Video>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Video>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Video>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Video>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Video>>() .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<Video>(testData.GetEnumerator()));

            dbSet.As<IQueryable<Video>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Video>(testData.Provider));

            Type type = typeof(Video);
            string colName = "VideoId";
            var pk = type.GetProperty(colName);
            if (pk == null)
            {
                colName = "VideoId";
                pk = type.GetProperty(colName);
            }
            if (pk != null)
            {
                dbSet.Setup(x => x.Remove(It.IsAny<Video>()))
                 .Callback<Video>((entity) => dbSet.Object.ToList().Remove(entity));

                dbSet.Setup(x => x.FindAsync(It.IsAny<object[]>()))
                    .Returns<object[]>(async ids =>
                    await dbSet.Object.FirstOrDefaultAsync(b => b.VideoId == (int)ids[0]));
            }

            Mock<CandidateContext> context = new Mock<CandidateContext>();
            context.Setup(x => x.Set<Video>()).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void AddVideo()
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
            VideoDTO videoDTO1 = new VideoDTO()
            {
                VideoGuid = guid,
                CandidateId = 1,
                IsUrl = false
            };

            // Create request 
            VideoDTO videoDTO2 = new VideoDTO()
            {
                VideoGuid = guid,
                //CandidateId = 1,
                //IsUrl = false
            };

            VideoValidations validator = new VideoValidations();
            ValidationResult result1 = validator.Validate(videoDTO1);
            ValidationResult result2 = validator.Validate(videoDTO2);

            Video video1 = mapper.Map<VideoDTO, Video>(videoDTO1);
            Video video2 = mapper.Map<VideoDTO, Video>(videoDTO2);

            VideoRepository videoRepository = new VideoRepository(candidateContext);
            bool created = await videoRepository.Add(video1);

            Assert.True(result1.IsValid == true); // Meets the validations
            Assert.True(result2.IsValid == false); // If not pass the validations, the candidate can't be created
            Assert.True(created); // Created successfully
        }

        [Fact]
        public async void GetAllVideos()
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
            VideoRepository videoRepository = new VideoRepository(mockContext.Object);

            List<Video> videos = await videoRepository.GetAll();

            // Tests
            Assert.True(videos.Any()); // True if candidates is not null
            Assert.True(videos.Count == testSize); // Length is equals to the initial value
        }
               
        //[Fact]
        //public async void GetCandidatesById()
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

        //    // Instance the Handler cvlass, using the Mocks
        //    CandidateRepository candidateRepository = new CandidateRepository(mockContext.Object);

        //    Candidate candidate = await candidateRepository.GetById(id);

        //    // Tests
        //    Assert.True(candidate != null); // True if candidate is not null
        //    Assert.True(candidate.CandidateId == id);
        //}

        [Fact]
        public async void GetVideoByGuid()
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
            VideoRepository videoRepository = new VideoRepository(mockContext.Object);

            Video video = await videoRepository.GetByGuid(guid);

            // Tests
            Assert.True(video != null); // True if candidate is not null
            Assert.True(video.VideoGuid == guid);
            Assert.True(video.CandidateId == 1);
        }

        [Fact]
        public async void GetVideoById()
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
            VideoRepository videoRepository = new VideoRepository(mockContext.Object);

            Video basicInfo = await videoRepository.GetById(id);

            // Tests
            Assert.True(basicInfo != null); // True if basicInfo is not null
            Assert.True(basicInfo.VideoId == id);
            //Assert.True(candidate.CandidateGuid == guid);
        }

        [Fact]
        public void DeleteVideo()
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
            VideoRepository videoRepository = new VideoRepository(mockContext.Object);

            Video video = new Video
            {
                VideoId = id,
                VideoGuid = guid,
                CandidateId = 1,
                IsUrl = false
            };

            var deleted = videoRepository.Remove(video.VideoId);

            // Tests         
            Assert.True(deleted != null);         
        }
        
    }
}
