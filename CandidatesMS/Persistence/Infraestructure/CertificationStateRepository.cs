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
    public class CertificationStateRepository : Repository<CertificationState>, ICertificationStateRepository
    {
        public CertificationStateRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<CertificationState> GetByCertificationStateId(int studyId)
        {
            CertificationState certificationState = await _entities.Where(x => x.CertificationStateId == studyId).FirstOrDefaultAsync();
            return certificationState;
        }
    }
}
