using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyRepository _currencyRepository;
        private IMapper _mapper;

        public CurrencyController(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ObjectResult> GetAllCurrencies()
        {
            try
            {
                List<Currency> currencies = await _currencyRepository.GetAllOrdered();

                List<CurrencyDTO> currenciesDTO = _mapper.Map<List<Currency>, List<CurrencyDTO>>(currencies);

                return Ok(new { message = "Monedas consultadas exitosamente", obj = currenciesDTO });

            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

    }

}
