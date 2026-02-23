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
    public class MentionMemberUserRepository : Repository<MentionMemberUser>, IMentionMemberUserRepository
    {
        public MentionMemberUserRepository(CandidateContext context) : base(context)
        {         
        }

        public async Task<bool> AddByMentionMemberUser(MentionMemberUser mentionMemberUser)
        {
            await _entities.AddAsync(mentionMemberUser);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> RemoveMentionByNote(int noteId)
        {
            try
            {
                var skills = await _entities.Where(x => x.NoteId == noteId).ToListAsync();
                if (skills.Count != 0)
                {
                    _entities.RemoveRange(skills);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<MentionMemberUser>> GetMentionsByNoteId(int noteId)
        {
            List<MentionMemberUser> mentionsMembers = await _entities.Where(x => x.NoteId == noteId).ToListAsync();

            return mentionsMembers;
        }
    }
}
