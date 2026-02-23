using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class FileTypeHiringRepository : Repository<FileTypeHiring>, IFileTypeHiringRepository
    {
        public FileTypeHiringRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<FileTypeHiring>> GetAllFileTypeHiring()
        {
            List<FileTypeHiring> fileTypeHirings = await _entities.OrderBy(x => x.OrderId).ToListAsync();

            return fileTypeHirings;
        }

        public async Task<List<FileTypeHiring>> GetAllFileTypeHiringWithoutTaxWithholding()
        {
            List<FileTypeHiring> fileTypeHirings = await _entities.Where(x => x.FileTypeHiringId != 26).OrderBy(x => x.OrderId).ToListAsync();

            return fileTypeHirings;
        }

        public async Task<List<FileTypeHiring>> GetAllFileTypeHiringCandidate()
        {
            List<FileTypeHiring> fileTypeHirings = await _entities
                .Where(x => x.FileTypeHiringId == 4 || x.FileTypeHiringId == 5 || x.FileTypeHiringId == 10 || x.FileTypeHiringId == 11 || x.FileTypeHiringId == 12
                            || x.FileTypeHiringId == 13 || x.FileTypeHiringId == 26).OrderBy(x => x.OrderId).ToListAsync();

            return fileTypeHirings;
        }
    }
}
