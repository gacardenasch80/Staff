

using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CandidatesMS.Persistence.DBContext
{
    public class CandidateContext : DbContext
    {
        public CandidateContext()
        { 
        }

        public IConfiguration Configuration { get; }

        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options) { }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<CandidateRecruitee> CandidateRecruitee { get; set; }
        public virtual DbSet<Study> Study { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<Candidate_TechnicalAbility> Candidate_TechnicalAbility { get; set; }
        public virtual DbSet<TechnicalAbilityLevel> TechnicalAbilityLevel { get; set; }
        public virtual DbSet<TechnicalAbilityTechnology> TechnicalAbilityTechnology { get; set; }
        public virtual DbSet<BasicInformation> BasicInformation { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<PersonalReference> PersonalReference { get; set; }
        public virtual DbSet<LifePreference> LifePreference { get; set; }
        public virtual DbSet<Candidate_LifePreference> Candidate_LifePreference { get; set; }
        public virtual DbSet<SoftSkill> SoftSkill { get; set; }
        public virtual DbSet<Candidate_SoftSkill> Candidate_SoftSkill { get; set; }
        public virtual DbSet<Description> Description { get; set; }
        public virtual DbSet<CV> CV { get; set; }
        public virtual DbSet<CVHiring> CVHiring { get; set; }
        public virtual DbSet<AttachedFile> AttachedFile { get; set; }
        public virtual DbSet<AttachedFileHiring> AttachedFileHiring { get; set; }
        public virtual DbSet<WorkExperience> WorkExperience { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<EquivalentPosition> EquivalentPosition { get; set; }
        public virtual DbSet<TimeAvailability> TimeAvailability { get; set; }
        public virtual DbSet<Wellness> Wellness { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LanguageOther> LanguageOther { get; set; }
        public virtual DbSet<LanguageLevel> LanguageLevel { get; set; }
        public virtual DbSet<Candidate_Language> Candidate_Language { get; set; }
        public virtual DbSet<Candidate_LanguageOther> Candidate_LanguageOther { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<StudyType> StudyTypeId { get; set; }
        public virtual DbSet<CertificationState> CertificationState { get; set; }
        public virtual DbSet<StudyArea> StudyArea{ get; set; }
        public virtual DbSet<RelationType> RelationType { get; set; }
        public virtual DbSet<ExperienceCount> ExperienceCount { get; set; }
        public virtual DbSet<Candidate_Wellness> Candidate_Wellness { get; set; }
        public virtual DbSet<Candidate_TimeAvailability> Candidate_TimeAvailability { get; set; }
        public virtual DbSet<Company_Candidate_Wellness> Company_Candidate_Wellness { get; set; }
        public virtual DbSet<Company_Candidate_TimeAvailability> Company_Candidate_TimeAvailability { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<FileTypeHiring> FileTypeHiring { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<UserLink> UserLink { get; set; }
        public virtual DbSet<SocialNetwork> SocialNetwork { get; set; }
        public virtual DbSet<StudyState> StudyState { get; set; }
        public virtual DbSet<CompanyDescription> CompanyDescription { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<MentionMemberUser> MentionMemberUser { get; set; }
        public virtual DbSet<DocumentCheck> DocumentCheck { get; set; }
        public virtual DbSet<DocumentCheckState> DocumentCheckState { get; set; }
        public virtual DbSet<DocumentCheckGroup> DocumentCheckGroup { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<AttachedFileMail> AttachedFileMail { get; set; }
        public virtual DbSet<CC> CC { get; set; }
        public virtual DbSet<CCO> CCO { get; set; }
        public virtual DbSet<RemoteMail> RemoteMail { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<CandidateCompany> CandidateCompany { get; set; }
        public virtual DbSet<RecruiteeCandidateRaw> RecruiteeCandidateRaw { get; set; }
        public virtual DbSet<JobProfession> JobProfession { get; set; }

        public virtual DbSet<Candidate_Postulation> Candidate_Postulation { get; set; }
        public virtual DbSet<Candidate_TalentGroupAux> Candidate_TalentGroup { get; set; }
        public virtual DbSet<Candidate_Tag> Candidate_Tag { get; set; }
        public virtual DbSet<Candidate_Source> Candidate_Source { get; set; }

        public virtual DbSet<AnalyzeCVData> AnalyzeCVData { get; set; }

        public virtual DbSet<CandidateOrigin> CandidateOrigin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            // Unique condition email
            modelBuilder.Entity<Candidate>()
                .HasIndex(i => i.Email).IsUnique();

            // Unique condition Experience Count CandidateId
            //modelBuilder.Entity<ExperienceCount>()
            //    .HasIndex(i => i.CandidateId).IsUnique();

            // Candidate_talentGroup From Company DB
            //modelBuilder.Entity< Persistence.EntitiesCompany.Candidate_TalentGroup >().OwnsOne(candidate_talentGroup => candidate_talentGroup.Candidate_TalentGroupId);
            //modelBuilder.Entity<Persistence.EntitiesCompany.Candidate_TalentGroup>().ToTable("Device");

        }

        //public System.Data.Linq.Table<TEntity> GetTable<TEntity>() where TEntity : class;
    }
}