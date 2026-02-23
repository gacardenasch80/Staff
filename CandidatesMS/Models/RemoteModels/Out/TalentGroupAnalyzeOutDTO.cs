using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class TalentGroupAnalyzeOutDTO
    {
        public List<int> Candidates { get; set; }
        public List<int> TalentGroups { get; set; }
    }
}
