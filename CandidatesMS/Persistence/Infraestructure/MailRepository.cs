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
    public class MailRepository : Repository<Mail>, IMailRepository
    {
        public MailRepository(CandidateContext context) : base(context)
        {
        }

        public new async Task<Mail> Add(Mail mail)
        {
            await _entities.AddAsync(mail);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return mail;

            return null;
        }

        public async Task<List<Mail>> GetAllMailByCandidateId(int candidateId, int companyUserId)
        {            
            List<Mail> mailList = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                                        .Include(x => x.AttachedFilesMail).Include(x => x.CC).Include(x => x.CCO)
                                        .AsNoTracking().ToListAsync();

            return mailList;
        }

        public async Task<List<Mail>> GetAllMailByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            List<Mail> mailList = await _entities.Where(x => x.CandidateId == candidateId && (x.CompanyUserId == companyUserId || x.CompanyUserId == 0))
                                        .Include(x => x.AttachedFilesMail).Include(x => x.CC).Include(x => x.CCO)
                                        .AsNoTracking().ToListAsync();

            return mailList;
        }
    }
}
