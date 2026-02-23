using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class ActionUserDTO
    {
        public int ActionUserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string StringId { get; set; }

        public List<Permission_ActionUserDTO> Permission_ActionUser { get; set; }
    }
}
