using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class NoteDTO
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; }
        public int MemberId { get; set; }
        public string CreationDate { get; set; }
        public int CandidateId { get; set; }
        public string FileName { get; set; }
        public string FileIdentifier { get; set; }
        public string FileUploadDate { get; set; }
        public string IdentifierLink { get; set; }
        public IFormFile FormFile { get; set; }
        public string CreationInfo { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public DateTime SortedDate { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }
        public string InitialsMember { get; set; }
        public string PhotoMember { get; set; }
        public bool PinUp { get; set; }
        public bool Available { get; set; }
        public bool KeepFile { get; set; }
        public string VacancyName { get; set; }
        public DateTime DatePinUp { get; set; }
        public int NoteOwnerId { get; set; }
        public List<int> Ids { get; set; }
        public List<NoteDTO> notesAnswers { get; set; }
        public CandidateDTO candidate { get; set; }
    }
}
