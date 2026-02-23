using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IMatchServerDate
    {
        string CreateServerDate();
        string CreateServerMonthDate();
        DateTime GetDateTimeByServer();
        DateTime GetDateTimeByFilterSixtyDays();
    }
    public class MatchServerDate : IMatchServerDate
    {
        public string CreateServerDate()
        {
            var dateServer = DateTime.Now.AddHours(-5).ToString();


            return dateServer;

        }

        public string CreateServerMonthDate()
        {
            var dateServer = DateTime.Now.AddHours(-5).ToString("MMMM");


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
    }
}
