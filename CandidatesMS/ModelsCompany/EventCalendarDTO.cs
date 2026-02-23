using CandidatesMS.Models.RemoteModels.In;
using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class EventCalendarDTO
    {
        public int EventId { get; set; }

        public int CompanyUserId { get; set; }
        public int MemberUserId { get; set; }

        public int CandidateId { get; set; }
        public string CandidateName { get; set; }

        public string CandidateInitials { get; set; }
        public string CandidatePhoto { get; set; }

        public string StringDate { get; set; }
        public string StringDateEnglish { get; set; }

        public string Location { get; set; }

        public string Note { get; set; }
        public string PrivateNote { get; set; }

        public bool IsCreatedFromThisMember { get; set; }

        public string UID { get; set; }

        public int CalendarEventId { get; set; }

        public DateNumbersDTO StartDate { get; set; }
        public DateNumbersDTO EndDate { get; set; }

        public EventTypeDTO EventType { get; set; }

        public PostulationDTO Postulation { get; set; }
        public Candidate_TGDTO TalentGroup { get; set; }

        public List<Event_MemberUserDTO> Inerviewers { get; set; }
    }
}
