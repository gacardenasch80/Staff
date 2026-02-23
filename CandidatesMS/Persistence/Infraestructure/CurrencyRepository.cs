using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<Currency>> GetAllOrdered()
        {
            List<Currency> currencyList = await _context.Currency
                .OrderBy(x => x.ShortName).ToListAsync();

            return currencyList;
        }

        public async Task<Currency> GetCurrency(int currencyId)
        {
            Currency currency = await _context.Currency.FirstOrDefaultAsync(x => x.CurrencyId == currencyId);
            return currency;
        }

        public async Task<List<Currency>> GetCurrencySearch(string search)
        {
            search = search.ToLower().TrimStart().TrimEnd()
                .Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");
            List<Currency> currencyList = await _context.Currency.Where(x => x.ShortName.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").Contains(search))
                .OrderBy(x => x.CurrencyId).ToListAsync();

            return currencyList;
        }

        //public async Task<Currency> GetById(int id)
        //{
        //    return await _context.Currency.SingleOrDefaultAsync(c => c.CurrencyId == id);
        //}
    }
}
