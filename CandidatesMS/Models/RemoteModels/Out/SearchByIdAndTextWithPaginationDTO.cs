using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class SearchByIdAndTextWithPaginationDTO
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool Ascending { get; set; }

        public int JobExperienceId { get; set; }
        public List<TechnicalAbilitiesFromSearch> TechnicalAbilities { get; set; }
        public List<LanguagesFromSearch> Languages { get; set; }
        public List<SalaryAspirationFromSearchDTO> SalaryAspirations { get; set; }
        public List<CountriesFromSearchDTO> Countries { get; set; }
        public List<string> Companies { get; set; }
        public int JobProfessionId { get; set; }
        public List<int> Tags { get; set; }
        public List<int> Sources { get; set; }
        public bool IsPotential { get; set; }

        public int EvaluationFilter { get; set; }
    }
}
