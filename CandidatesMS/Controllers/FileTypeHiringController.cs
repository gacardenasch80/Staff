using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileTypeHiringController: ControllerBase
    {

        private IFileTypeHiringRepository _fileHiringRepository;
        private IMapper _mapper;
        public FileTypeHiringController(IMapper mapper,IFileTypeHiringRepository fileTypeHiringRepository)
        {
            _mapper = mapper;
            _fileHiringRepository = fileTypeHiringRepository;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllFileTypeHiring()
        {
            try
            {

                List<FileTypeHiring> fileTypeHirings = await _fileHiringRepository.GetAllFileTypeHiringWithoutTaxWithholding();

                if (fileTypeHirings != null && fileTypeHirings.Count() != 0)
                {
                    List<FileTypeHiringDTO> fileTypesDTO = _mapper.Map<List<FileTypeHiring>, List<FileTypeHiringDTO>>(fileTypeHirings);

                    return Ok(new { message = "Tipos de archivos consultados exitosamente", obj = fileTypesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron tipos de archivos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            
        }

        [HttpGet("candidates")]
        public async Task<ObjectResult> GetAllFileTypeHiringCandidate()
        {
            try
            {

                List<FileTypeHiring> fileTypeHirings = await _fileHiringRepository.GetAllFileTypeHiringCandidate();

                if (fileTypeHirings != null && fileTypeHirings.Count() != 0)
                {
                    List<FileTypeHiringDTO> fileTypesDTO = _mapper.Map<List<FileTypeHiring>, List<FileTypeHiringDTO>>(fileTypeHirings);

                    return Ok(new { message = "Tipos de archivos consultados exitosamente", obj = fileTypesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron tipos de archivos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
