using CandidatesMS.Models.RemoteModels.In;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class CompanyCostRegisterDTO
    {
        public int CompanyCostRegisterId { get; set; }

        public DateTime RegisterDate { get; set; }

        public int JobsPublished { get; set; }
        public int TalentGroupsPublished { get; set; }
        public int CVSCreatedManually { get; set; }
        public int CVSCreatedViaAnalysis { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUserDTO CompanyUser { get; set; }
    }
}
