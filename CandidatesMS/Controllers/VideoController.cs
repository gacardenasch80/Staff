using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IAWSS3FileService _AWSS3FileService;
        private IVideoRepository _videoRepository;
        private ICandidateRepository _candidateRepository;
        private IMapper _mapper;

        public VideoController(IVideoRepository videoRepository, ICandidateRepository candidateRepository, IMapper mapper, IAWSS3FileService AWSS3FileService)
        {
            _videoRepository = videoRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _AWSS3FileService = AWSS3FileService;
        }

        [RequestSizeLimit(60000000)]
        [HttpPost]
        public async Task<IActionResult> AddURLVideo([FromBody] VideoDTO videoDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(videoDTO.CandidateId);
                if (candidateExists)
                {
                    Video video = _mapper.Map<VideoDTO, Video>(videoDTO);
                    video.VideoGuid = Convert.ToString(Guid.NewGuid());
                    video.IsUrl = true; // It is URL

                    bool created = await _videoRepository.Add(video);
                    object[] ans = await _candidateRepository.EditEditionDate(videoDTO.CandidateId);

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        videoDTO = _mapper.Map<Video, VideoDTO>(video);

                        return Created("", new { message = "URL del video fue almacenada exitosamente", obj = videoDTO });
                    }
                    else
                        return BadRequest(new { message = "La URL del video no fue almacenada" });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [RequestSizeLimit(60000000)]
        [Route("uploadVideo")]
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] VideoDTO req)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);
                if (candidateExists)
                {
                    // Save video to AWS S3
                    string result = await _AWSS3FileService.UploadFile(req.FormFile, "Video");

                    // Create data in Database
                    Video video = _mapper.Map<VideoDTO, Video>(req);
                    video.VideoGuid = Convert.ToString(Guid.NewGuid());
                    video.IsUrl = false; // It isn't URL
                    video.VideoName = result;

                    bool created = await _videoRepository.Add(video);
                    object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        req = _mapper.Map<Video, VideoDTO>(video);

                        return Created("", new { message = "Video almacenado exitosamente en S3", obj = req });
                    }
                    else
                        return BadRequest(new { message = "La URL del video no fue almacenada" });
                    //return Ok(new { isSucess = result });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [RequestSizeLimit(60000000)]
        [HttpGet]
        public async Task<IActionResult> GetAllVideos()
        {
            try
            {
                List<Video> videos = await _videoRepository.GetAll();

                if (videos != null && videos.Count > 0)
                {
                    List<VideoDTO> videosDTO = _mapper.Map<List<Video>, List<VideoDTO>>(videos);

                    return Ok(new { message = "URLs de videos consultadas exitosamente", obj = videosDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron URLs de videos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [RequestSizeLimit(60000000)]
        [HttpGet("{videoId}")]
        public async Task<ObjectResult> GetVideoById(int videoId)
        {
            try
            {
                Video video = await _videoRepository.GetById(videoId);

                if (video != null)
                {
                    VideoDTO videoDTO = _mapper.Map<Video, VideoDTO>(video);

                    return Ok(new { message = "URL de video consultada exitosamente", obj = videoDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la la URL del video" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [RequestSizeLimit(60000000)]
        [HttpGet("guid/{videoGuid}")]
        public async Task<ObjectResult> GetVideoByGuid(string videoGuid)
        {
            try
            {
                Video video = await _videoRepository.GetByGuid(videoGuid);

                if (video != null)
                {
                    VideoDTO videoDTO = _mapper.Map<Video, VideoDTO>(video);

                    return Ok(new { message = "URL de videop consultada exitosamente", obj = videoDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la URL del video" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [RequestSizeLimit(60000000)]
        [HttpGet("candidate/{candidateId}")]
        public async Task<ObjectResult> GetVideoByCandidateId(int candidateId)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
                if (candidateExists)
                {
                    bool videoExists = await _videoRepository.VideoExists(candidateId);

                    if (videoExists)
                    {
                        Video video = await _videoRepository.GetByCandidateId(candidateId);

                        if (video != null)
                        {
                            VideoDTO videoDTO = _mapper.Map<Video, VideoDTO>(video);

                            if ((bool)video.IsUrl)
                            {
                                return Ok(new { message = "URL del video consultada exitosamente", obj = videoDTO, isTrue = videoExists });
                            }
                            else
                            {
                                return Ok(new { message = "Video de S3 consultado exitosamente", obj = videoDTO, isTrue = videoExists });
                            }
                        }
                        else
                            return Ok(new { message = "No se encontró un video asociado al candidato", obj = new VideoDTO(), isTrue = videoExists });
                    }
                    else
                        return NotFound(new { message = "No se encontró un video asociada al candidato", obj = new VideoDTO(), isTrue = videoExists });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, isTrue = false });
            }
        }

        [RequestSizeLimit(60000000)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            try
            {
                Video video = await _videoRepository.GetById(id);
                bool videoExists = true;

                if (video == null)
                {
                    videoExists = false;
                    return NotFound(new { message = "El video del candidato no fue encontrado.", isTrue = videoExists });
                }

                await _videoRepository.Remove(video.VideoId);
                object[] ans = await _candidateRepository.EditEditionDate(video.CandidateId);

                VideoDTO videoDTO = _mapper.Map<Video, VideoDTO>(video);

                if (ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return Ok(new { message = "Video del candidato eliminado exitosamente.", obj = videoDTO, isTrue = videoExists });
                }

                return StatusCode(500, new { message = "Eliminación fallida" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
