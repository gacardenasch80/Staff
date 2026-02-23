namespace CandidatesMS.ModelsCompany
{
    public class EvaluationCriteriaDTO
    {
        public int EvaluationCriteriaId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxPercent { get; set; }
        public int Value { get; set; }

        public bool IsMandatory { get; set; }

        public int NumberTimes { get; set; }

        public int NumberTimesRed { get; set; }
        public int NumberTimesYellow { get; set; }
        public int NumberTimesGreen { get; set; }

        /**/

        public double Percent { get; set; }
        public string PercentFormat { get; set; }

        public double ValueAverage { get; set; }

        public int ColourFlag { get; set; } // 1 Red, 2 Yellow, 3 Green

        /**/

        public int EvaluationCriteriaTypeId { get; set; }
        public int CompanyUserId { get; set; }
    }
}
