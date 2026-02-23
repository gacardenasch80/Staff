using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateFullDTO
    {
        public int CandidateId { get; set; }
        public string Email { get; set; }

        //

        public int CompanyUserId { get; set; }

        public string CreationDate { get; set; }
        public string CreationInfo { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public string EditionDate { get; set; }
        public string DeleteDate { get; set; }
        public string DeleteInfoPup { get; set; }
        public string FirstLoginDate { get; set; }
        public string FirstLoginInfoPup { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }

        //

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }

        //

        public BasicInformationFullDTO BasicInformation { get; set; }

        //

        public List<VideoDTO> VideoList { get; set; }
        public List<Candidate_LanguageFullDTO> Candidate_Language { get; set; }
        public List<LanguageOtherDTO> LanguageOther { get; set; }
        public List<Candidate_SoftSkillDTO> Candidate_SoftSkillList { get; set; }
        public List<WorkExperienceDTO> WorkExperienceList { get; set; }
    }
}
