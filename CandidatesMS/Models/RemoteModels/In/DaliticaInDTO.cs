using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class DaliticaInDTO
    {
        public string timestamp { get; set; }
        public string documentName { get; set; }
        public DaliticaResultInDTO result { get; set; }
    }

    public class DaliticaResultInDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> emails { get; set; }
        public List<string> phoneNumbers { get; set; }
        public string dateOfBirth { get; set; }
        public string totalYearsOfExperience { get; set; }
        public string profession { get; set; } // Ask about this field
        public string summary { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public List<string> skills { get; set; }
        public List<DaliticaEducationInDTO> education { get; set; }
        public List<DaliticaExperienceInDTO> experience { get; set; }
        public List<DaliticaTrainingAndCertificationsInDTO> trainingAndCertifications { get; set; }
        public List<DaliticaLanguagesInDTO> languages { get; set; }
    }

    public class DaliticaEducationInDTO
    {
        public string degree { get; set; }
        public string school { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
    }

    public class DaliticaExperienceInDTO
    {
        public bool is_current { get; set; }
        public string position { get; set; }
        public string company { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string location { get; set; }
        public string description { get; set; }
    }

    public class DaliticaTrainingAndCertificationsInDTO
    {
        public string year { get; set; }
        public string organization { get; set; }
        public string description { get; set; }
    }

    public class DaliticaLanguagesInDTO
    {
        public string name { get; set; }
        public int level { get; set; } // Ask about this Id
    }
}
