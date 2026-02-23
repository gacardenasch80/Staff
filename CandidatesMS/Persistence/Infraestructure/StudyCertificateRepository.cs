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
    public class StudyCertificateRepository : Repository<StudyCertificate>, IStudyCertificateRepository
    {
        public StudyCertificateRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<StudyCertificate> GetByStudyId(int studyCertificateId)
        {
            StudyCertificate studyCertificate = await _entities.Where(x => x.StudyId == studyCertificateId).FirstOrDefaultAsync();
            return studyCertificate;
        
        }
    }
}
