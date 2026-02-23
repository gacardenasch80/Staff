using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using S3bucketDemo.Services;
using System;
using AutoMapper;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Models;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachedFileMailController : ControllerBase
    {
        private IAWSS3FileService _AWSS3FileService;
        private IAttachedFileMailRepository _attachedFileMailRepository;
        private IMapper _mapper;

        public AttachedFileMailController(IAWSS3FileService AWSS3FileService, IAttachedFileMailRepository attachedFileMailRepository, IMapper mapper)
        {
            _AWSS3FileService = AWSS3FileService;
            _attachedFileMailRepository = attachedFileMailRepository;
            _mapper = mapper;
        }

        [HttpGet("download/{attachedFileId}")]
        public async Task<FileResult> GetFileDownloadByCandidateId(int attachedFileId)
        {
            byte[] byteArr;
            AttachedFileMail file = await _attachedFileMailRepository.GetById(attachedFileId);
            if (file == null)
                return null;
            try
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(file.FileIdentifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);

                string[] urlSplit = file.FileIdentifier.Split("/");
                string identifier = string.Empty;

                if(urlSplit != null && urlSplit.Length > 0)
                {
                    identifier = urlSplit[urlSplit.Length - 2] + "/" + urlSplit[urlSplit.Length - 1];
                }

                Stream stream = await _AWSS3FileService.GetFile(identifier);

                using (var memoryStream = new MemoryStream())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }

                var result = File(byteArr, "application/octet-stream");
                result.FileDownloadName = Regex.Replace(file.Name, @"[^0-9a-zA-Z.]+", "");

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("downloadAnswerFile")]
        public async Task<FileResult> GetAnswerFileDownloadByCandidateId([FromBody] AttachedFileMail file)
        {
            byte[] byteArr;

            try
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(file.FileIdentifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);

                string[] urlSplit = file.FileIdentifier.Split("/");
                string identifier = string.Empty;

                if (urlSplit != null && urlSplit.Length > 0)
                {
                    identifier = urlSplit[urlSplit.Length - 2] + "/" + urlSplit[urlSplit.Length - 1];
                }

                Stream stream = await _AWSS3FileService.GetFile(identifier);

                string name = "";

                var addressSplit = file.FileIdentifier.Split("/");
                if (addressSplit != null && addressSplit.Length > 0)
                {
                    name = addressSplit[addressSplit.Length - 1];
                }

                using (var memoryStream = new MemoryStream())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }

                var result = File(byteArr, "application/octet-stream");
                result.FileDownloadName = Regex.Replace(name, @"[^0-9a-zA-Z.]+", "");

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
