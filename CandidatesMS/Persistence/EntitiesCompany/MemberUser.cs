using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class MemberUser
    {
        public int MemberUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LoginCode { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }

        public bool ShowNewFeatures { get; set; }

        public int CandidateProfileId { get; set; }
        public DateTime CandidateProfileDate { get; set; }

        public CompanyUser CompanyUser { get; set; }
        public int CompanyUserId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }
        public int State { get; set; }
        public ICollection<MemberUserTalentGroup> MemberUserTalentGroup { get; set; }
        public ICollection<FollowJob> FollowJob { get; set; }
        public ICollection<FollowTalentGroup> FollowTalentGroup { get; set; }
        public ICollection<Notification> Notification { get; set; }

        public ICollection<Job_MemberUser> Job_MemberUser { get; set; }
        public ICollection<MemberUser_TGComercial> memberUser_TGComercial { get; set; }
        public ICollection<SearchHistory> searchHistory { get; set; }
        public ICollection<Event_MemberUser> Event_MemberUser { get; set; }

        public ICollection<CalendarEvent> CalendarEvent { get; set; }

        public ICollection<ICS> ICSs { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<Evaluation_EvaluationCriteria> Evaluation_EvaluationCriteria { get; set; }

    }
}
