using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class JobListsDTO
    {
        public int JobId { get; set; }

        public string? PublicationDate { get; set; }
        public string CreationDate { get; set; }
        public string? ClosingDate { get; set; }
        public string? FilingDate { get; set; }
        public string? DeletionDate { get; set; }
        public string? EditedDate { get; set; }
        public DateTime SortedDate { get; set; }
        public string PreviousInfo { get; set; }
        public string PreviousInfoEnglish { get; set; }
        public string PreviousToltip { get; set; }
        public string PreviousToltipEnglish { get; set; }

        public string CreationDateToltip { get; set; }
        public string PublicationDateToltip { get; set; }
        public string ClosingDateToltip { get; set; }
        public string FilingDateToltip { get; set; }
        public string DeletionDateToltip { get; set; }
        public string EditedDateToltip { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? ShowSalary { get; set; }
        public bool? IsRemote { get; set; }
        public bool? Following { get; set; }
        public bool IsEdit { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string MemberEmail { get; set; }
        public string JobSalary { get; set; }
        public string JobSectorName { get; set; }

        public bool IsCreationAndPublication { get; set; }
        public bool IsConfidential { get; set; }

        /**/
        public int CountQualified { get; set; }
        public int CountDisqualified { get; set; }
        public int CountCandidates { get; set; }
        /**/

        public int CompanyUserId { get; set; }
        public CompanyUserJobsDTO companyUser { get; set; }
        public JobPostingStatusDTO JobPostingStatus { get; set; }

        public int? JobStatusId { get; set; }
        public JobLevelDTO JobLevel { get; set; }
        public JobSubLevelDTO JobSubLevel { get; set; }
        public WorkAreaDTO WorkArea { get; set; }
        public JobContractDTO JobContract { get; set; }
        public JobEducationLevelDTO JobEducationLevel { get; set; }
        public JobExperienceDTO JobExperience { get; set; }
        public JobModalityDTO JobModality { get; set; }
        public JobSectorDTO JobSector { get; set; }
        public Job_OtherSectorDTO Job_OtherSector { get; set; }
        public InternalCodeDTO InternalCode { get; set; }
        public JobCurrencyDTO JobCurrency { get; set; }
        public JobLocationModalityDTO JobLocationModality { get; set; }

        public int JobTypeId { get; set; }
        public JobTypeDTO JobType { get; set; }

        /**/

        public int JobLocationId { get; set; }
        public JobLocationDTO JobLocation { get; set; }

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
