using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IFileTypeHiringRepository: IRepository<FileTypeHiring>
    {

        Task<List<FileTypeHiring>> GetAllFileTypeHiring();
        Task<List<FileTypeHiring>> GetAllFileTypeHiringWithoutTaxWithholding();
        Task<List<FileTypeHiring>> GetAllFileTypeHiringCandidate();

    }
}
