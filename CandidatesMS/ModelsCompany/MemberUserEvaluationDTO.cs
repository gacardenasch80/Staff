namespace CandidatesMS.ModelsCompany
{
    public class MemberUserEvaluationDTO
    {
        public int MemberUserId { get; set; }

        public string NameMemberUser { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }
        public string PhotoName { get; set; }

        public string Initials { get; set; }

        public bool MemberDeleted { get; set; }
    }
}
