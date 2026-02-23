using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Entities;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {                
        private ITitleRepository _titlerepository;
        private IMapper _mapper;

        public TitleController(ITitleRepository titlerepository, IMapper mapper)
        {
            _titlerepository = titlerepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTitles()
        {
            try
            {
                List<Title> titles = await _titlerepository.GetAll();

                if (titles != null && titles.Count > 0)
                {
                    return Ok(new { message = "Titulos consultados exitosamente", obj = titles });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron titulos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{titleId}")]
        public async Task<ObjectResult> GetTitleById(int titleId)
        {
            try
            {
                Title title = await _titlerepository.GetById(titleId);

                if (title != null)
                {
                    return Ok(new { message = "Titulos consultado exitosamente", obj = title });
                }
                else
                {
                    return NotFound(new { message = "No se encontró titulo" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }        
    }   
}
