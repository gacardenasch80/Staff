using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public partial class RecruiteeNotesinDTO
    {
        public NoteRecruitee[] notes { get; set; }
        public Reference[] references { get; set; }
    }

    public partial class NoteRecruitee
    {
        public long adminId { get; set; }
        public Attachment[] attachments { get; set; }
        public string body { get; set; }
        public string bodyHtml { get; set; }
        public object bodyJson { get; set; }
        public long candidateId { get; set; }
        public string created_at { get; set; }
        public long guestId { get; set; }
        public long id { get; set; }
        public long offerId { get; set; }
        public string pinned_at { get; set; }
        public object[] reactions { get; set; }
        public NoteRecruitee[] replies { get; set; }
        public bool replyToId { get; set; }
        public long requisitionId { get; set; }
        public string text { get; set; }
        public bool triggered { get; set; }
        public string updated_at { get; set; }
        public VisibilityNote visibility { get; set; }
    }

    public partial class Attachment
    {
        public long adminId { get; set; }
        public long candidateId { get; set; }
        public string created_at { get; set; }
        public string extension { get; set; }
        public long fileSize { get; set; }
        public Uri file_url { get; set; }
        public string filename { get; set; }
        public long guestId { get; set; }
        public long id { get; set; }
        public string kind { get; set; }
        public long noteId { get; set; }
        public long offerId { get; set; }
        public Uri pdfThumbnailUrl { get; set; }
        public Uri pdfUrl { get; set; }
        public long requisitionId { get; set; }
        public string status { get; set; }
        public string uploader { get; set; }
    }

    public partial class VisibilityNote
    {
        public long[] adminIds { get; set; }
        public string level { get; set; }
        public long[] roleIds { get; set; }
    }

    public partial class Reference
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public bool hasAvatar { get; set; }
        public long id { get; set; }
        public string initials { get; set; }
        public string lastName { get; set; }
        public Uri photoNormalUrl { get; set; }
        public Uri photoThumbUrl { get; set; }
        public bool timeFormat24 { get; set; }
        public string timezone { get; set; }
        public string type { get; set; }
    }
}
