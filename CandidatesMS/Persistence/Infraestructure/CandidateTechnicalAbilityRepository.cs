using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CandidatesMS.Persistence.Infraestructure;

namespace CandidatesMS.Infraestructure
{
    public class CandidateTechnicalAbilityRepository : Repository<Candidate_TechnicalAbility>, ICandidateTechnicalAbilityRepository
    {
        public CandidateTechnicalAbilityRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_TechnicalAbility>> GetAllWithLevel()
        {
            List<Candidate_TechnicalAbility> candidateTechnicalAbilities = await _entities.Include(x => x.TechnicalAbilityLevel).AsNoTracking().ToListAsync();

            if (candidateTechnicalAbilities != null && candidateTechnicalAbilities.Count > 0)
            {
                foreach (Candidate_TechnicalAbility candidateTechnicalAbility in candidateTechnicalAbilities)
                {
                    candidateTechnicalAbility.Candidate = null;
                }
            }

            return candidateTechnicalAbilities;
        }

        public async Task<List<Candidate_TechnicalAbility>> GetAllWithLevelAndTechnology()
        {
            List<Candidate_TechnicalAbility> candidateTechnicalAbilities = await _entities.Include(x => x.TechnicalAbilityLevel).Include(x => x.TechnicalAbilityTechnology).AsNoTracking().ToListAsync();

            if (candidateTechnicalAbilities != null && candidateTechnicalAbilities.Count > 0)
            {
                foreach (Candidate_TechnicalAbility candidateTechnicalAbility in candidateTechnicalAbilities)
                {
                    candidateTechnicalAbility.Candidate = null;
                }
            }

            return candidateTechnicalAbilities;
        }

        public async Task<List<Candidate_TechnicalAbility>> GetByCandidateId(int candidateId)
        {
            List<Candidate_TechnicalAbility> techAbilities = await _context.Candidate_TechnicalAbility
                .Where(x => x.CandidateId == candidateId).AsNoTracking()
                .Include(l => l.TechnicalAbilityLevel)
                .AsNoTracking()
                .ToListAsync();

            return techAbilities;
        }

        public async Task<List<Candidate_TechnicalAbility>> GetByCandidateIdMaster(int candidateId)
        {
            List<Candidate_TechnicalAbility> techAbilities = await _context.Candidate_TechnicalAbility
                .Where(x => x.CandidateId == candidateId && x.IsFromEmpresaAdded != true)
                .Include(l => l.TechnicalAbilityLevel)
                .AsNoTracking()
                .ToListAsync();

            return techAbilities;
        }

        public async Task<Candidate_TechnicalAbility> GetByGuid(string candidateTechnicalAbilityGuid)
        {
            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
                .Where(x => x.Candidate_TechnicalAbilityGuid == candidateTechnicalAbilityGuid)
                .Include(t => t.Discipline)
                .Include(l => l.TechnicalAbilityLevel).AsNoTracking()
                .FirstOrDefaultAsync();

            return techAbility;
        }

        public async Task<bool> ExistByIds(int? technicalAbilityTechnologyId, int candidateId)
        {
            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
                .Where( x => x.TechnicalAbilityTechnologyId == technicalAbilityTechnologyId &&
                 x.CandidateId == candidateId && x.IsFromEmpresaAdded != true).AsNoTracking()
                .FirstOrDefaultAsync();

            if (techAbility != null)
                return true;
            else
                return false;            
        }

        public async Task<bool> ExistByIdAndName(string name, int candidateId)
        {
            TechnicalAbilityTechnology tech = await _context.TechnicalAbilityTechnology.Where(x => x.Technology == name).FirstOrDefaultAsync();

            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
                .Where(x => x.Other == name && x.IsFromEmpresaAdded != true && x.CandidateId == candidateId).AsNoTracking()
                .FirstOrDefaultAsync();

            if (techAbility != null || tech != null)
                return true;
            else
                return false;
        }

        public async  Task<Candidate_TechnicalAbility> GetSkillcanditateByid(int candidate_TechnicalAbilityId)
        {
            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
              .Where(x => x.Candidate_TechnicalAbilityId == candidate_TechnicalAbilityId)
              .Include(l => l.TechnicalAbilityLevel).AsNoTracking()
              .FirstOrDefaultAsync();

            return techAbility;
        }

        public async  Task<bool> ExistByIdsOnCompany(int? technicalAbilityTechnologyId, int candidateId)
        {
            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
                .Where(x => x.TechnicalAbilityTechnologyId == technicalAbilityTechnologyId &&
                x.CandidateId == candidateId && x.IsFromEmpresaAdded == true).AsNoTracking()
                .FirstOrDefaultAsync();

            if (techAbility != null)
                return true;
            else
                return false;
        }

        public async Task<bool> ExistByIdAndNameOnCompany(string name, int candidateId)
        {
            TechnicalAbilityTechnology tech = await _context.TechnicalAbilityTechnology.Where(x => x.Technology == name).FirstOrDefaultAsync();

            Candidate_TechnicalAbility techAbility = await _context.Candidate_TechnicalAbility
                .Where(x => x.Other == name && x.IsFromEmpresaAdded == true && x.CandidateId == candidateId).AsNoTracking()
                .FirstOrDefaultAsync();

            if (techAbility != null || tech != null)
                return true;
            else
                return false;
        }

        public bool UpdateOwn(Candidate_TechnicalAbility candidateTechnicalAbility)
        {
            _entities.Update(candidateTechnicalAbility);
            int states = _context.SaveChanges();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<List<Candidate_TechnicalAbility>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_TechnicalAbility> techAbilities = await _entities.Where(x => x.CandidateId == candidateId && (x.IsFromEmpresaAdded == false || (x.IsFromEmpresaAdded == true && x.CompanyUserId == companyUserId))).ToListAsync();

            return techAbilities;
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
