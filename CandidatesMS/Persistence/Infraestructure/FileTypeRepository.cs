using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class FileTypeRepository : Repository<FileType>, IFileTypeRepository
    {
        public FileTypeRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<FileType>> GetFourFileTypes()
        {
            List<FileType> fileTypes = await _entities.Where(x => x.OrderList > 0).OrderBy(x => x.OrderList).ToListAsync();
            return fileTypes;

        }
    }
}