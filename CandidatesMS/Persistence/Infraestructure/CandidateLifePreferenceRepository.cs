using AutoMapper;
using CandidatesMS.Mapping;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CandidatesMS.Repositories;
using CandidatesMS.Persistence.Infraestructure;

namespace CandidatesMS.Infraestructure
{
    public class CandidateLifePreferenceRepository : Repository<Candidate_LifePreference>, ICandidateLifePreferenceRepository
    {
        public CandidateLifePreferenceRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_LifePreference>> GetByCandidateId(int candidateId, bool isFromCandidate)
        {
            List<Candidate_LifePreference> candidateLifePreferences = await _entities
            .Where(x => x.CandidateId == candidateId && x.IsFromCandidate == isFromCandidate)
            .Include(x => x.LifePreference)
            .AsNoTracking()
            .ToListAsync();            

            return candidateLifePreferences;
        }

        public async Task<bool> ExistsByCandidateAndLifePreferenceId(int candidateId, int lifePreferenceId, bool isFromCandidate)
        {
            Candidate_LifePreference candidateLifePreference = await _context.Candidate_LifePreference
            .Where(x => x.CandidateId == candidateId && x.LifePreferenceId == lifePreferenceId && x.IsFromCandidate == isFromCandidate)
            .AsNoTracking()
            .FirstOrDefaultAsync();

            if (candidateLifePreference != null)
                return true;

            return false;
        }

        public async Task<Candidate_LifePreference> GetByGuid(string candidateLifePreferenceGuid)
        {
            Candidate_LifePreference lifePreference = await _context.Candidate_LifePreference
                .Where(x => x.Candidate_LifePreferenceGuid == candidateLifePreferenceGuid)
                .Include(x => x.LifePreference).FirstOrDefaultAsync();

            //Candidate_LifePreferenceDTO candidateLifePreferenceDTO = _mapper.Map<Candidate_LifePreference, Candidate_LifePreferenceDTO>(lifePreference);

            return lifePreference;
        }

        public async Task<List<Candidate_LifePreference>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_LifePreference> lifePreferences = await _entities
                .Where(x => x.CandidateId == candidateId && (x.IsFromCandidate == true || (x.IsFromCandidate == false && x.CompanyUserId == companyUserId)))
                .Include(x => x.LifePreference)
                .ToListAsync();

            return lifePreferences;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
