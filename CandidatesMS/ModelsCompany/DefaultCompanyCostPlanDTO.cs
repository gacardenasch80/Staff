namespace CandidatesMS.ModelsCompany
{
    public class DefaultCompanyCostPlanDTO
    {
        public int DefaultCompanyCostPlanId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxJobsPublished { get; set; }
        public int MaxTalentGroupsPublished { get; set; }
        public int MaxCVSCreatedManually { get; set; }
        public int MaxCVSCreatedViaAnalysis { get; set; }

        public bool IsCVsAnalysisAllowed { get; set; }
    }
}
