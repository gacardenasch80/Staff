namespace CandidatesMS.ModelsCompany
{
    public class ActionUserWithAuxFieldsDTO
    {
        public int ActionUserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string StringId { get; set; }

        public int Permission_ActionUserId { get; set; }
        public int PermissionId { get; set; }
    }
}
