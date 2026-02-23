using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IMentionMemberUserRepository : IRepository<MentionMemberUser>
    {
        Task<bool> AddByMentionMemberUser(MentionMemberUser mentionMemberUser);
        Task<bool> RemoveMentionByNote(int noteId);
        Task<List<MentionMemberUser>> GetMentionsByNoteId(int noteId);
    }
}
