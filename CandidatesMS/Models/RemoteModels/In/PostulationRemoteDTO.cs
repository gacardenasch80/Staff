using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class PostulationRemoteDTO
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Job
        {
            public int jobId { get; set; }
            public int companyUserId { get; set; }
            public string publicationDate { get; set; }
            public string creationDate { get; set; }
            public object creationInfo { get; set; }
            public string editedDate { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public bool showSalary { get; set; }
            public bool isRemote { get; set; }
            public object following { get; set; }
            public bool isEdit { get; set; }
            public object workArea { get; set; }
            public object internalCode { get; set; }
            public JobPostingStatus jobPostingStatus { get; set; }
            public JobLocation jobLocation { get; set; }
            public JobContract jobContract { get; set; }
            public JobExperience jobExperience { get; set; }
            public JobLanguage jobLanguage { get; set; }
            public JobLanguageLevel jobLanguageLevel { get; set; }
            public JobCurrency jobCurrency { get; set; }
            public JobLocationModality jobLocationModality { get; set; }
            public object otherLanguage { get; set; }
            public object jobModality { get; set; }
            public string jobSalary { get; set; }
        }

        

        public class JobContract
        {
            public int jobContractId { get; set; }
            public string contract { get; set; }
        }

        public class JobExperience
        {
            public int jobExperienceId { get; set; }
            public string experience { get; set; }
        }

        public class JobLanguage
        {
            public int jobLanguageId { get; set; }
            public string language { get; set; }
        }

        public class JobLanguageLevel
        {
            public int jobLanguageLevelId { get; set; }
            public string languageLevel { get; set; }
        }

        public class JobLocation
        {
            public int jobLocationId { get; set; }
            public string country { get; set; }
            public string region { get; set; }
            public string city { get; set; }
            public string address { get; set; }
            public string countryName { get; set; }
            public string regionName { get; set; }
            public string cityName { get; set; }
        }

        public class JobPostingStatus
        {
            public int jobPostingStatusId { get; set; }
            public string status { get; set; }
            public string statusAction { get; set; }
        }

        public class Obj
        {
            public int postulationId { get; set; }
            public int candidateId { get; set; }
            public object candidateEmail { get; set; }
            public DateTime postulationDate { get; set; }
            public DateTime postulationBlockDate { get; set; }
            public object blockDate { get; set; }
            public object blockDatePup { get; set; }
            public object blockReasonId { get; set; }
            public object blockReason { get; set; }
            public int jobId { get; set; }
            public Job job { get; set; }
            public int postulationStageId { get; set; }
            public PostulationStage postulationStage { get; set; }
            public object candidate { get; set; }
            public bool sendMail { get; set; }
            public int disqualificationReasonId { get; set; }
            public object disqualificationReason { get; set; }
            public bool isCreatedByCandidate { get; set; }
            public string textState { get; set; }
            public int textColor { get; set; }

            public bool acceptResponses { get; set; }
        }

        public class PostulationStage
        {
            public int postulationStageId { get; set; }
            public string name { get; set; }
            public int postulationStateId { get; set; }
            public PostulationState postulationState { get; set; }
        }

        public class PostulationState
        {
            public int postulationStateId { get; set; }
            public string name { get; set; }
        }

        public class JobLocationModality
        {
            public int jobLocationModalityId { get; set; }
            public string name { get; set; }
        }

        public class JobCurrency
        {
            public int jobCurrencyId { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }

        }

        public class Root
        {
            public string message { get; set; }
            public List<Obj> obj { get; set; }
        }


    }

    public class PostulationDTO
    {
        public string message { get; set; }
        public List<Postulation> obj { get; set; }
    }

    public class Postulation
    {
        public int postulationId { get; set; }
        public int candidateId { get; set; }
        public object candidateEmail { get; set; }
        public DateTime postulationDate { get; set; }
        public DateTime postulationBlockDate { get; set; }
        public object blockDate { get; set; }
        public object blockDatePup { get; set; }
        public object blockReasonId { get; set; }
        public object blockReason { get; set; }
        public int jobId { get; set; }
        public int companyUserId { get; set; }
        public int postulationStageId { get; set; }
        public object candidate { get; set; }
        public bool sendMail { get; set; }
        public int disqualificationReasonId { get; set; }
        public object disqualificationReason { get; set; }
        public bool isCreatedByCandidate { get; set; }
        public string textState { get; set; }
        public int textColor { get; set; }

        public bool acceptResponses { get; set; }

        public List<AnswerInDTO> answers { get; set; }
    }
}
