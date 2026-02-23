using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class PersonalReferenceRepository : Repository<PersonalReference>, IPersonalReferenceRepository
    {
        public PersonalReferenceRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<PersonalReference>> GetToOverview(int candidateId, int companyUserId)
        {
            List<PersonalReference> personalReferences = await _entities.Where(x => x.CandidateId == candidateId && (x.IsAddefromCompany == false || (x.IsAddefromCompany == true && x.CompanyUserId == companyUserId)))
                .Include(x => x.RelationType).ToListAsync();

            return personalReferences;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }

        public async Task<List<PersonalReference>> GetByCandidateId(int candidateId)
        {
            List<PersonalReference> personalReference = await _entities.Where(x => x.CandidateId == candidateId)
                                                              .Include(x => x.RelationType ).ToListAsync();

            return personalReference;
        }

        public async Task<List<PersonalReference>> GetByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<PersonalReference> personalReference = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                                                              .Include(x => x.RelationType).ToListAsync();

            return personalReference;
        }

        public async Task<PersonalReference> GetpersonalreferenceById(int personalReferenceId)
        {
            PersonalReference personalRef = await _context.PersonalReference
                .Where(x => x.PersonalReferenceId == personalReferenceId).AsNoTracking()
                //.Include(x => x.Candidate)
                .FirstOrDefaultAsync();


            return personalRef;

        }
    }
}
