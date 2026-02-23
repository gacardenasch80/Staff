namespace CandidatesMS.Persistence.Entities
{
    public class CCO
    {
        public int CCOId { get; set; }
        public string Email { get; set; }
        public int MailId { get; set; }
        public Mail Mail { get; set; }
    }
}
