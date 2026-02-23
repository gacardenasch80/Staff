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
    public class FileTypeController : ControllerBase
    {
        private IFileTypeRepository _fileTypeRepository;
        private IMapper _mapper;

        public FileTypeController(IFileTypeRepository fileTypeRepository,  IMapper mapper)
        {
            _fileTypeRepository = fileTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetFourFileTypes()
        {
            List<FileType> fileTypes = await _fileTypeRepository.GetFourFileTypes();

            if (fileTypes != null && fileTypes.Count() != 0)
            {
                List<FileTypeDTO> fileTypesDTO = _mapper.Map<List<FileType>, List<FileTypeDTO>>(fileTypes);

                return Ok(new { message = "Tipos de archivos consultados exitosamente", obj = fileTypesDTO });
            }
            else
            {
                return NotFound(new { message = "No se encontraron tipos de archivos." });
            }
        }
    }
}
