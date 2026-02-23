using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class JobDTO
    {
        public int JobId { get; set; }

        public bool Publish { get; set; }
        public string? CreationDate { get; set; }
        public string? PublicationDate { get; set; }
        public string? ClosingDate { get; set; }
        public string? FilingDate { get; set; }
        public string? DeletionDate { get; set; }
        public string? EditedDate { get; set; }

        public string PreviousInfo { get; set; }
        public string PreviousToltip { get; set; }

        public string CreationDateToltip { get; set; }
        public string PublicationDateToltip { get; set; }
        public string ClosingDateToltip { get; set; }
        public string FilingDateToltip { get; set; }
        public string DeletionDateToltip { get; set; }
        public string EditedDateToltip { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? ShowSalary { get; set; }
        public string? Gender { get; set; }
        public bool? IsRemote { get; set; }
        public int? Validity { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string MemberEmail { get; set; }
        public string JobSalary { get; set; }
        public string JobSectorName { get; set; }

        public bool IsCreationAndPublication { get; set; }
        public bool IsConfidential { get; set; }

        /**/

        public int? CompanyUserId { get; set; }

        public int? JobPostingStatusId { get; set; }

        public int? JobStatusId { get; set; }

        public int? JobLevelId { get; set; }

        public int? JobSubLevelId { get; set; }

        public int? WorkAreaId { get; set; }

        public int? JobContractId { get; set; }

        public int? JobEducationLevelId { get; set; }

        public int? JobExperienceId { get; set; }

        public int? JobModalityId { get; set; }

        public int? JobSectorId { get; set; }

        public int? InternalCodeId { get; set; }

        public int JobCurrencyId { get; set; }

        public int JobLocationModalityId { get; set; }

        public int JobTypeId { get; set; }

        /**/

        public int? JobLocationId { get; set; }
        public JobLocationDTO JobLocation { get; set; }

        public Job_OtherSectorDTO Job_OtherSector { get; set; }

        /**/

        public ICollection<FollowJobDTO> FollowJob { get; set; }
        public ICollection<PostulationDTO> Postulations { get; set; }

        public ICollection<Job_JobSoftSkillDTO> Job_JobSoftSkill { get; set; }
        public ICollection<Job_JobTechnicalAbilityDTO> Job_JobTechnicalAbility { get; set; }
        public ICollection<Job_OtherTechnicalAbilityDTO> Job_OtherTechnicalAbility { get; set; }
        public ICollection<Job_JobProfessionDTO> Job_JobProfession { get; set; }
        public ICollection<Job_OtherProfessionDTO> Job_OtherProfession { get; set; }
        public ICollection<Job_JobLanguageDTO> Job_JobLanguage { get; set; }
        public ICollection<Job_OtherLenguageDTO> Job_OtherLanguage { get; set; }

        public ICollection<QuestionDTO> Questions { get; set; }
    }
}
