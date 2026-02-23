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
    public class CompanyCandidateJobPreferenceRepository : Repository<Company_Candidate_Wellness>, ICompanyCandidateJobPreferenceRepository
    {
        public CompanyCandidateJobPreferenceRepository(CandidateContext context) : base(context)
        {
        }

        #region Company Candidate Wellness

        public async Task<List<Company_Candidate_Wellness>> GetCompanyCandidateWellnessByCandidateId(int candidateId)
        {
            List<Company_Candidate_Wellness> companyCandidateWellness = await _entities
            .Where(x => x.CandidateId == candidateId)
            .Include(x => x.Wellness)
            .AsNoTracking()
            .ToListAsync();

            return companyCandidateWellness;
        }

        public async Task<List<Company_Candidate_Wellness>> GetCompanyCandidateWellnessByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            List<Company_Candidate_Wellness> companyCandidateWellness = await _entities
            .Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
            .Include(x => x.Wellness)
            .AsNoTracking()
            .ToListAsync();

            return companyCandidateWellness;
        }

        public async Task<bool> AddCompanyCandidateWellness(int candidateId, List<Company_Candidate_Wellness> companyCandidateWellness)
        {
            List<Company_Candidate_Wellness> oldCompanyCandidateWellness = await _context.Company_Candidate_Wellness.Where(x => x.CandidateId == candidateId).ToListAsync();

            if (oldCompanyCandidateWellness != null && oldCompanyCandidateWellness.Count > 0)
                _context.RemoveRange(oldCompanyCandidateWellness);

            await _context.Company_Candidate_Wellness.AddRangeAsync(companyCandidateWellness);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<Company_Candidate_Wellness> RemoveCompanyCandidateWellness(Company_Candidate_Wellness companyCandidateWellness)
        {
            _entities.Remove(companyCandidateWellness);

            var states = await _context.SaveChangesAsync();

            if (states != 0)
                return companyCandidateWellness;

            return null;
        }

        public async Task<Company_Candidate_Wellness> GetCompanyCandidateWellnessByIds(int candidateId, int wellnessId)
        {
            Company_Candidate_Wellness candidateWellness = await _context.Company_Candidate_Wellness
                .Where(x => x.CandidateId == candidateId && x.WellnessId == wellnessId).FirstOrDefaultAsync();

            return candidateWellness;
        }

        public bool UpdateCompanyCandidateWellnessByIds(Company_Candidate_Wellness candidateWellness)
        {
            _context.Company_Candidate_Wellness.Update(candidateWellness);

            return true;
        }

        #endregion


        #region Candidate Time Availability

        public async Task<List<Company_Candidate_TimeAvailability>> GetCompanyCandidateTimeAvailabilityByCandidateId(int candidateId)
        {
            List<Company_Candidate_TimeAvailability> companyCandidateTimeAvailabilities = await _context.Company_Candidate_TimeAvailability
            .Where(x => x.CandidateId == candidateId)
            .Include(x => x.TimeAvailability)
            .AsNoTracking()
            .ToListAsync();

            return companyCandidateTimeAvailabilities;
        }

        public async Task<List<Company_Candidate_TimeAvailability>> GetCompanyCandidateTimeAvailabilityByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            List<Company_Candidate_TimeAvailability> companyCandidateTimeAvailabilities = await _context.Company_Candidate_TimeAvailability
            .Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
            .Include(x => x.TimeAvailability)
            .AsNoTracking()
            .ToListAsync();

            return companyCandidateTimeAvailabilities;
        }

        public async Task<bool> AddCompanyCandidateTimeAvailabilities(int candidateId, List<Company_Candidate_TimeAvailability> companyCandidateTimeAvailabilities)
        {
            List<Company_Candidate_TimeAvailability> oldCompanyCandidateTimeAvailabilities = await _context.Company_Candidate_TimeAvailability.Where(x => x.CandidateId == candidateId).ToListAsync();

            if (oldCompanyCandidateTimeAvailabilities != null && oldCompanyCandidateTimeAvailabilities.Count > 0)
                _context.RemoveRange(oldCompanyCandidateTimeAvailabilities);

            await _context.Company_Candidate_TimeAvailability.AddRangeAsync(companyCandidateTimeAvailabilities);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<Company_Candidate_TimeAvailability> RemoveCompanyCandidateTimeAvailability(Company_Candidate_TimeAvailability companyCandidateTimeAvailability)
        {
            _context.Company_Candidate_TimeAvailability.Remove(companyCandidateTimeAvailability);

            var states = await _context.SaveChangesAsync();

            if (states != 0)
                return companyCandidateTimeAvailability;

            return null;
        }

        public async Task<Company_Candidate_TimeAvailability> GetCompanyCandidateTimeAvailabilityByIds(int candidateId, int timeAvailabilityId)
        {
            Company_Candidate_TimeAvailability candidateTimeAvailability = await _context.Company_Candidate_TimeAvailability
                .Where(x => x.CandidateId == candidateId && x.TimeAvailabilityId == timeAvailabilityId).FirstOrDefaultAsync();

            return candidateTimeAvailability;
        }

        public bool UpdateCompanyCandidateTimeByIds(Company_Candidate_TimeAvailability candidateTime)
        {
            _context.Company_Candidate_TimeAvailability.Update(candidateTime);

            return true;
        }

        #endregion

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
