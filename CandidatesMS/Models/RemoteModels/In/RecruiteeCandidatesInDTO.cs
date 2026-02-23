using System;
using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class LanguageRecruiteeInDTO
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native_name { get; set; }
    }

    public class PlacementRecruiteeInDTO
    {
        public int candidate_id { get; set; }
        public DateTime created_at { get; set; }
        public int? id { get; set; }
        public LanguageRecruiteeInDTO language { get; set; }
        public int offer_id { get; set; }
        public object overdue_at { get; set; }
        public object overdue_diff { get; set; }
        public int position { get; set; }
        public int? stage_id { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class RatingsRecruiteeInDTO
    {
    }

    public class CandidateRecruiteeInDTO
    {
        public int? admin_id { get; set; }
        public string adminapp_url { get; set; }
        public DateTime created_at { get; set; }
        public List<string> emails { get; set; }
        public bool example { get; set; }
        public bool followed { get; set; }
        public int? id { get; set; }
        public object last_message_at { get; set; }
        public object my_last_rating { get; set; }
        public bool my_pending_result_request { get; set; }
        public bool my_upcoming_event { get; set; }
        public string name { get; set; }
        public int notes_count { get; set; }
        public bool pending_result_request { get; set; }
        public List<string> phones { get; set; }
        public string photo_thumb_url { get; set; }
        public List<PlacementRecruiteeInDTO> placements { get; set; }
        public object positive_ratings { get; set; }
        public double rating { get; set; }
        public RatingsRecruiteeInDTO ratings { get; set; }
        public int ratings_count { get; set; }
        public string referrer { get; set; }
        public string source { get; set; }
        public int tasks_count { get; set; }
        public bool unread_notifications { get; set; }
        public bool upcoming_event { get; set; }
        public DateTime updated_at { get; set; }
        public bool viewed { get; set; }
    }

    public class ReferenceRecruiteeInDTO
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
        public string lang_code { get; set; }
        public string category { get; set; }
        public DateTime? created_at { get; set; }
        public bool? locked { get; set; }
        public string name { get; set; }
        public object placements_count { get; set; }
        public object time_limit { get; set; }
        public DateTime? updated_at { get; set; }
    }

    public class CandidatesRecruiteeInDTO
    {
        public List<CandidateRecruiteeInDTO> candidates { get; set; }
        public DateTime generated_at { get; set; }
        public List<ReferenceRecruiteeInDTO> references { get; set; }
    }


}
