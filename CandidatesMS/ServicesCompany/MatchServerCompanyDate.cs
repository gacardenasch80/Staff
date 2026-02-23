using System;
using System.Globalization;

namespace CandidatesMS.ServicesCompany
{
    public interface IMatchServerCompanyDateService
    {
        string CreateServerDate();
        DateTime GetDateTimeByServer();
        DateTime GetDateTimeByFilterSixtyDays();
        DateTime GetDateWithString(string millisecondTime);
    }

    public class MatchServerCompanyDateService : IMatchServerCompanyDateService
    {
        public string CreateServerDate()
        {
            string dateServer = DateTime.Now.ToLocalTime().AddHours(-5).ToString();

            return dateServer;
        }

        public DateTime GetDateTimeByServer()
        {
            DateTime dateTimeServer = DateTime.Now.AddHours(-5);

            return dateTimeServer;
        }

        public DateTime GetDateTimeByFilterSixtyDays()
        {
            DateTime dateTimeServer = DateTime.Now.AddHours(-5);
            DateTime dateFilter = dateTimeServer.AddDays(-60);

            return dateFilter;
        }

        public DateTime GetDateWithString(string millisecondTime)
        {
            DateTime publicationDate = DateTime.Now;

            string[] validformats = [ "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt" ];

            if (DateTime.TryParseExact(millisecondTime, validformats, CultureInfo.InvariantCulture, DateTimeStyles.None, out publicationDate)) { }
            else
                publicationDate = Convert.ToDateTime(millisecondTime);
            
            return publicationDate;

        }
    }
}
