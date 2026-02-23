using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class MemberUserDTO
    {
        public int MemberUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LoginCode { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }
        public bool ShowNewFeatures { get; set; }
        public int CompanyUserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameEnglish { get; set; }
        public IFormFile FormFile { get; set; }
        public RoleDTO Role { get; set; }
        public int State { get; set; }

        public string Password { get; set; }

        public bool MemberDeleted { get; set; }

        public int CandidateProfileId { get; set; }
        public DateTime CandidateProfileDate { get; set; }
        public string Initials { get; set; }
        public ICollection<Job_MemberUserDTO> Job_MemberUser { get; set; }
        public ICollection<MemberUser_TGComercialDTO> memberUser_TGComercial { get; set; }

        public ICollection<CalendarEventDTO> CalendarEvent { get; set; }
    }
}
