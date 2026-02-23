namespace CandidatesMS.Models
{
    public class CCDTO
    {
        public int CCId { get; set; }
        public string Email { get; set; }
        public int MailId { get; set; }
        public MailDTO Mail { get; set; }
    }
}
