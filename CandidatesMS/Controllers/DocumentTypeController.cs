using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        IDocumentTypeRepository _documentTypeRepository;
        private IMapper _mapper;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            try
            {
                List<DocumentType> documentTypes = await _documentTypeRepository.GetAllWithOtherInEnd();

                if (documentTypes != null && documentTypes.Count > 0)
                {
                    List<DocumentTypeDTO> documentTypesDTO = _mapper.Map<List<DocumentType>, List<DocumentTypeDTO>>(documentTypes);

                    return Ok(new { message = "Tipos de documentos consultados exitosamente", obj = documentTypesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron tipos de documentos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{documentTypeId}")]
        public async Task<ObjectResult> GetDocumentTypeById(int documentTypeId)
        {
            try
            {
                DocumentType documentType = await _documentTypeRepository.GetById(documentTypeId);

                if (documentType != null)
                {
                    DocumentTypeDTO documentTypeDTO = _mapper.Map<DocumentType, DocumentTypeDTO>(documentType);

                    return Ok(new { message = "Tipo de documento consultado exitosamente", obj = documentTypeDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el tipo de documento" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{documentTypeGuid}")]
        public async Task<ObjectResult> GetDocumentTypeByGuid(string documentTypeGuid)
        {
            try
            {
                DocumentType documentType = await _documentTypeRepository.GetByGuid(documentTypeGuid);

                if (documentType != null)
                {
                    DocumentTypeDTO documentTypeDTO = _mapper.Map<DocumentType, DocumentTypeDTO>(documentType);

                    return Ok(new { message = "Tipo de documento consultado exitosamente", obj = documentTypeDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el tipo de documento" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
