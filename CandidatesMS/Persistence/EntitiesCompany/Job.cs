using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job
    {
        public int JobId { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? FilingDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public DateTime? JobValidity { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public bool ShowSalary { get; set; }
        public string? Gender { get; set; }
        public bool? IsRemote { get; set; }
        public bool IsEdit { get; set; }
        public int? Validity { get; set; }
        public int CompanyUserId { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string MemberEmail { get; set; }
        public string JobSalary { get; set; }
        public int? JobStatusId { get; set; }
        public string JobSectorName { get; set; }
        public bool IsCreationAndPublication { get; set; }
        public bool IsConfidential { get; set; }

        /**/

        public JobPostingStatus JobPostingStatus { get; set; }
        public int? JobPostingStatusId { get; set; }

        public int? InternalCodeId { get; set; }
        public InternalCode InternalCode { get; set; }

        public int? JobLocationId { get; set; }
        public JobLocation JobLocation { get; set; }

        public int? JobLevelId { get; set; }
        public JobLevel JobLevel { get; set; }

        public int? JobSubLevelId { get; set; }
        public JobSubLevel JobSubLevel { get; set; }

        public int? WorkAreaId { get; set; }
        public WorkArea WorkArea { get; set; }

        public int? JobContractId { get; set; }
        public JobContract JobContract { get; set; }

        public int? JobEducationLevelId { get; set; }
        public JobEducationLevel JobEducationLevel { get; set; }

        public int? JobExperienceId { get; set; }
        public JobExperience JobExperience { get; set; }

        public int? JobModalityId { get; set; }
        public JobModality JobModality { get; set; }

        public int? JobSectorId { get; set; }
        public JobSector JobSector { get; set; }

        public Job_OtherSector Job_OtherSector { get; set; }

        public int JobCurrencyId { get; set; }
        public JobCurrency JobCurrency { get; set; }

        public int JobLocationModalityId { get; set; }
        public JobLocationModality JobLocationModality { get; set; }

        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }

        /**/

        public ICollection<FollowJob> FollowJob { get; set; }
        public ICollection<Postulation> Postulations { get; set; }

        public ICollection<Job_JobSoftSkill> Job_JobSoftSkill { get; set; }
        public ICollection<Job_JobTechnicalAbility> Job_JobTechnicalAbility { get; set; }
        public ICollection<Job_OtherTechnicalAbility> Job_OtherTechnicalAbility { get; set; }
        public ICollection<Job_JobProfession> Job_JobProfession { get; set; }
        public ICollection<Job_OtherProfession> Job_OtherProfession { get; set; }
        public ICollection<Job_JobLanguage> Job_JobLanguage { get; set; }
        public ICollection<Job_OtherLanguage> Job_OtherLanguage { get; set; }
        public ICollection<Job_MemberUser> Job_MemberUser { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
