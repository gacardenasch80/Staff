using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<List<Currency>> GetAllOrdered(); 
        Task<Currency> GetCurrency(int currencyId);
        Task<List<Currency>> GetCurrencySearch(string search);
        //Task<Currency> GetById(int id);
    }
}
