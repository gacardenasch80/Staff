using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class CandidateOutDTO
    {
        public object gdpr_expires_at { get; set; }
        public string gdpr_status { get; set; }
        public string name { get; set; }
        public List<string> social_links { get; set; }
        public string cv_original_url { get; set; }
        public List<string> phones { get; set; }
        public object gdpr_consent_request_type { get; set; }
        public bool gdpr_consent_ever_given { get; set; }
        public string photo_url { get; set; }
        public List<string> emails { get; set; }
        public List<string> tags { get; set; }
        public List<string> sources { get; set; }
        public bool in_active_share { get; set; }
        public int? admin_id { get; set; }
        public bool pending_request_link { get; set; }
        public object gdpr_scheduled_to_delete_at { get; set; }
        public object my_last_rating { get; set; }
        public int notes_count { get; set; }
        public string source { get; set; }
        public object gdpr_consent_request_sent_at { get; set; }
        public List<object> referral_referrers_ids { get; set; }
        public List<object> links { get; set; }
        public double rating { get; set; }
        public int? id { get; set; }
        public object gdpr_consent_request_completed_at { get; set; }
        public string cv_url { get; set; }
        public string photo_thumb_url { get; set; }
    }

    public class ReferenceOut
    {
        public int? id { get; set; }
        public string kind { get; set; }
        public string location { get; set; }
        public int position { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string photo_thumb_url { get; set; }
    }

    public class RecruiteeCandidateOutDTO
    {
        public CandidateOutDTO candidate { get; set; }
        public List<ReferenceOut> references { get; set; }
    }
}
