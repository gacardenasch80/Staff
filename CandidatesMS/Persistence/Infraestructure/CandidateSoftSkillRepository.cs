using AutoMapper;
using CandidatesMS.Mapping;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CandidatesMS.Persistence.Infraestructure;

namespace CandidatesMS.Infraestructure
{
    public class CandidateSoftSkillRepository : Repository<Candidate_SoftSkill>, ICandidateSoftSkillRepository
    {
        public CandidateSoftSkillRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_SoftSkill>> GetByCandidateId(int candidateId)
        {            
            List<Candidate_SoftSkill> candidateSoftSkills = await _entities.Include(x => x.SoftSkill)
                .AsNoTracking()
                .ToListAsync();

            return candidateSoftSkills;
        }

        public async Task<List<Candidate_SoftSkill>> GetByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            List<Candidate_SoftSkill> candidateSoftSkills = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                .Include(x => x.SoftSkill)
                .AsNoTracking()
                .ToListAsync();

            return candidateSoftSkills;
        }

        public async Task<List<Candidate_SoftSkill>> GetByCandidateIdAndNoCompany(int candidateId)
        {
            List<Candidate_SoftSkill> candidateSoftSkills = await _entities.Where(x => x.CandidateId == candidateId && !x.IsFromEmpresaAdded)
                .Include(x => x.SoftSkill)
                .AsNoTracking()
                .ToListAsync();

            return candidateSoftSkills;
        }

        public async Task<bool> ExistsByCandidateAndSoftSkillIdDescription(int candidateId, int Candidate_SoftSkillId)
        {
            Candidate_SoftSkill candidateSoftSkill = await _context.Candidate_SoftSkill
            .Where(x => x.CandidateId == candidateId && x.Candidate_SoftSkillId == Candidate_SoftSkillId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

            if (candidateSoftSkill != null)            
                return true;            

            return false;
        }

        public async Task<bool> ExistsByCandidateAndSoftSkillId(int candidateId, int softSkillId)
        {
            Candidate_SoftSkill candidateSoftSkill = await _context.Candidate_SoftSkill.Where(x => x.CandidateId == candidateId && x.SoftSkillId == softSkillId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

            if (candidateSoftSkill != null)
                return true;

            return false;
        }

        public async Task<Candidate_SoftSkill> GetByGuid(string candidateSoftSkillGuid)
        {
            Candidate_SoftSkill candidateSoftSkill = await context.Candidate_SoftSkill
                .Where(x => x.Candidate_SoftSkillGuid == candidateSoftSkillGuid)
                .Include(x => x.SoftSkill).FirstOrDefaultAsync();

            //Candidate_SoftSkillDTO candidateSoftSkillDTO = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(candidateSoftSkill);

            return candidateSoftSkill;
        }

        public async Task RemovefromByCandidateIdAsync(int candidateId)
        {
            var skills = await _entities.Where(x => x.CandidateId == candidateId && x.IsFromEmpresaAdded==true).ToListAsync();
            _entities.RemoveRange(skills);
            _context.SaveChanges();
        }

        public async Task<List<Candidate_SoftSkill>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_SoftSkill> softSkills = await _entities.Where(x => x.CandidateId == candidateId && (x.IsFromEmpresaAdded == false || (x.IsFromEmpresaAdded == true && x.CompanyUserId == companyUserId))).ToListAsync();

            return softSkills;
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
