using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class Value
    {
        public string degree { get; set; }
        public string description { get; set; }
        public string end_date { get; set; }
        public string major { get; set; }
        public string school { get; set; }
        public string start_date { get; set; }
        public string company { get; set; }
        public object location { get; set; }
        public string title { get; set; }
    }

    public class Visibility
    {
        public List<object> admin_ids { get; set; }
        public string level { get; set; }
        public List<object> role_ids { get; set; }
    }

    public class Field
    {
        public bool @fixed { get; set; }
        public int? id { get; set; }
        public string kind { get; set; }
        public string origin { get; set; }
        public List<Value> values { get; set; }
        public Visibility visibility { get; set; }
        public bool visible { get; set; }
    }

    public class Placement
    {
        public int candidate_id { get; set; }
        public DateTime created_at { get; set; }
        public int? id { get; set; }
        public object language { get; set; }
        public int offer_id { get; set; }
        public object overdue_at { get; set; }
        public object overdue_diff { get; set; }
        public int position { get; set; }
        public object stage_id { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Ratings
    {
    }

    public class CandidateInDTO
    {
        public object gdpr_expires_at { get; set; }
        public object cover_letter { get; set; }
        public string gdpr_status { get; set; }
        public DateTime updated_at { get; set; }
        public string name { get; set; }
        public List<string> social_links { get; set; }
        public List<object> admin_ids { get; set; }
        public string cv_original_url { get; set; }
        public bool followed { get; set; }
        public object referrer { get; set; }
        public int attachments_count { get; set; }
        public List<string> phones { get; set; }
        public int tasks_count { get; set; }
        public object gdpr_consent_request_type { get; set; }
        public bool gdpr_consent_ever_given { get; set; }
        public object sourcing_data { get; set; }
        public bool example { get; set; }
        public string adminapp_url { get; set; }
        public string photo_url { get; set; }
        public List<Field> fields { get; set; }
        public DateTime created_at { get; set; }
        public List<string> emails { get; set; }
        public List<string> tags { get; set; }
        public object last_message_at { get; set; }
        public bool in_active_share { get; set; }
        public int? admin_id { get; set; }
        public bool pending_request_link { get; set; }
        public object gdpr_scheduled_to_delete_at { get; set; }
        public List<Placement> placements { get; set; }
        public object my_last_rating { get; set; }
        public int notes_count { get; set; }
        public string source { get; set; }
        public object gdpr_consent_request_sent_at { get; set; }
        public List<object> referral_referrers_ids { get; set; }
        public bool viewed { get; set; }
        public string cv_processing_status { get; set; }
        public List<string> sources { get; set; }
        public List<int> duplicates { get; set; }
        public List<object> grouped_open_question_answers { get; set; }
        public object online_data { get; set; }
        public DateTime last_activity_at { get; set; }
        public List<object> links { get; set; }
        public bool upcoming_event { get; set; }
        public double rating { get; set; }
        public List<object> custom_fields { get; set; }
        public bool my_pending_result_request { get; set; }
        public bool my_upcoming_event { get; set; }
        public int mailbox_messages_count { get; set; }
        public List<object> open_question_answers { get; set; }
        public int ratings_count { get; set; }
        public object sourcing_origin { get; set; }
        public int? id { get; set; }
        public bool unread_notifications { get; set; }
        public object positive_ratings { get; set; }
        public object gdpr_consent_request_completed_at { get; set; }
        public bool pending_result_request { get; set; }
        public string cv_url { get; set; }
        public string photo_thumb_url { get; set; }
        public Ratings ratings { get; set; }
    }

    public class ReferenceIn
    {
        public int? id { get; set; }
        public string kind { get; set; }
        public string location { get; set; }
        public int position { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object offer_ids { get; set; }
        public string photo_normal_url { get; set; }
        public string photo_thumb_url { get; set; }
        public bool? time_format24 { get; set; }
        public string timezone { get; set; }
        public bool? view_all_jobs { get; set; }
    }

    public class RecruiteeCandidateInDTO
    {
        public CandidateInDTO candidate { get; set; }
        public List<ReferenceIn> references { get; set; }
    }
}
