namespace CandidatesMS.ModelsCompany
{
    public class SearchHistoryDTO
    {
        public int SearchHistoryId { get; set; }
        public int? CandidateId { get; set; }
        public int? TalentGroupId { get; set; }
        public int? JobId { get; set; }
        public int MemberUserId { get; set; }
    }
}
