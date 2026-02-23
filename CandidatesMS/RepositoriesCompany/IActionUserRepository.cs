using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IActionUserRepository : IRepositoryCompany<ActionUser>
    {
        Task<ActionUserDTO> GetByValidationString(string validationString);
    }
}
