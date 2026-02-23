using CandidatesMS.Persistence.EntitiesCompany;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CandidatesMS.Persistence.DBContext
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public IConfiguration Configuration { get; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        public virtual DbSet<BlockReason> BlockReason { get; set; }
        public virtual DbSet<Candidate_BlockReason> Candidate_BlockReason { get; set; }
        public virtual DbSet<Candidate_Source> Candidate_Source { get; set; }
        public virtual DbSet<Candidate_Tag> Candidate_Tag { get; set; }
        public virtual DbSet<Candidate_TalentGroup> Candidate_TalentGroup { get; set; }
        public virtual DbSet<CompanyUser> CompanyUser { get; set; }
        public virtual DbSet<DefaultBlockReason> DefaultBlockReason { get; set; }
        public virtual DbSet<DefaultEvaluationCriteria> DefaultEvaluationCriteria { get; set; }
        public virtual DbSet<DefaultPercentCriteria> DefaultPercentCriteria { get; set; }
        public virtual DbSet<DisqualificationReason> DisqualificationReason { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<EvaluationCriteria> EvaluationCriteria { get; set; }
        public virtual DbSet<EvaluationCriteriaType> EvaluationCriteriaType { get; set; }
        public virtual DbSet<Job_JobProfession> Job_JobProfession { get; set; }
        public virtual DbSet<JobProfession> JobProfession { get; set; }
        public virtual DbSet<MemberUser> MemberUser { get; set; }
        public virtual DbSet<MemberUser_TGComercial> MemberUser_TGComercial { get; set; }
        public virtual DbSet<PercentCriteria> PercentCriteria { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
    }
}