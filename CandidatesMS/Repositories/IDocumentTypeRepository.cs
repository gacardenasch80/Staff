using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
        Task<List<DocumentType>> GetAllWithOtherInEnd();
        Task<DocumentType> GetByGuid(string Guid);
        Task<DocumentType> GetByDocumentTypeId(int documentTypeId);
    }
}
