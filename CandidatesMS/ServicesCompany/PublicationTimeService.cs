using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CandidatesMS.ServicesCompany
{
    public interface IPublicationTimeService
    {
        public string GetFileTypeCreationInfoPup(string millisecondTime);
        public string GetFileTypeCreationInfoPupEnglish(string millisecondTime);
        public string GetEvaluationsInfo(string millisecondTime);
        public string GetEvaluationsInfoEnglish(string millisecondTime);
        public string GetBlockPupInfo(DateTime blockDate);
        public string GetCreationInfoPupEnglish(string millisecondTime);
        public DateTime CreateServerDate();
    }
    public class PublicationTimeService
    (
        IMatchServerCompanyDateService matchServerCompanyDate
    )
    :
    IPublicationTimeService
    {

        private IMatchServerCompanyDateService _matchServerCompanyDate = matchServerCompanyDate;

        public string GetFileTypeCreationInfoPup(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) { }

                else
                {
                    try
                    {
                        string dateRemove = millisecondTime;

                        if (millisecondTime.ToString().Contains("a. m."))
                        {
                            dateRemove = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if (millisecondTime.ToString().Contains("p. m."))
                        {
                            dateRemove = Regex.Replace(millisecondTime, "p. m.", "PM");
                        }
                        else if (millisecondTime.ToString().Contains("a."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');

                            dateRemove = auxDate[0] + " " + auxDate[1];
                        }
                        else if (millisecondTime.ToString().Contains("p."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');

                            dateRemove = auxDate[0] + " " + auxDate[1] + " PM";
                        }

                        creationDate = Convert.ToDateTime(dateRemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                string publicationDate = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("es-CO"));

                return publicationDate;
            }
            else
            {
                return "No existe fecha.";
            }
        }

        public string GetFileTypeCreationInfoPupEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) { }

                else
                {
                    try
                    {
                        string removeDate = millisecondTime;

                        if (millisecondTime.ToString().Contains("a. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if (millisecondTime.ToString().Contains("p. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "p. m.", "PM");
                        }
                        else if (millisecondTime.ToString().Contains("a."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');

                            removeDate = auxDate[0] + " " + auxDate[1];
                        }
                        else if (millisecondTime.ToString().Contains("p."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');

                            removeDate = auxDate[0] + " " + auxDate[1] + " PM";
                        }

                        creationDate = Convert.ToDateTime(removeDate.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                string publicationDate = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-CO"));

                return publicationDate;
            }
            else
            {
                return "There is no date.";
            }
        }

        public string GetEvaluationsInfo(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) { }

                else
                {
                    try
                    {
                        string removeDate = millisecondTime;

                        if (millisecondTime.ToString().Contains("a. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if (millisecondTime.ToString().Contains("p. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "p. m.", "PM");
                        }
                        else if (millisecondTime.ToString().Contains("a."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');
                            
                            removeDate = auxDate[0] + " " + auxDate[1];
                        }
                        else if (millisecondTime.ToString().Contains("p."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');

                            removeDate = auxDate[0] + " " + auxDate[1] + " PM";
                        }

                        creationDate = Convert.ToDateTime(removeDate.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                DateTime publicationDate = Convert.ToDateTime(creationDate);

                DateTime dateTimeServer = _matchServerCompanyDate.GetDateTimeByServer();
                
                TimeSpan publicationTime = publicationDate - dateTimeServer;

                if (publicationTime.Hours > 0)
                {
                    if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                    {
                        return "Se agregará dentro de " + Convert.ToInt32(publicationTime.Days).ToString() + " días.";
                    }

                    return "Se agregará dentro de " + Convert.ToInt32(publicationTime.Hours).ToString() + " horas.";
                }
                else
                {
                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        return "Última agregada hace " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        return "Última agregada hace " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        return "Última agregada hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        return "Última agregada hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                    }

                    return "Última agregada hace " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                }
            }
            else
            {
                return "Última gregada hace 1 día.";
            }
        }

        public string GetEvaluationsInfoEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) { }

                else
                {
                    try
                    {
                        string removeDate = millisecondTime;

                        if (millisecondTime.ToString().Contains("a. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if (millisecondTime.ToString().Contains("p. m."))
                        {
                            removeDate = Regex.Replace(millisecondTime, "p. m.", "PM");
                        }
                        else if (millisecondTime.ToString().Contains("a."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');
                            
                            removeDate = auxDate[0] + " " + auxDate[1];
                        }
                        else if (millisecondTime.ToString().Contains("p."))
                        {
                            string[] auxDate = millisecondTime.Trim().ToString().Split(' ');
                            
                            removeDate = auxDate[0] + " " + auxDate[1] + " PM";
                        }

                        creationDate = Convert.ToDateTime(removeDate.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                DateTime publicationDate = Convert.ToDateTime(creationDate);

                DateTime dateTimeServer = _matchServerCompanyDate.GetDateTimeByServer();

                TimeSpan publicationTime = publicationDate - dateTimeServer;

                if (publicationTime.Hours > 0)
                {
                    if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                    {
                        return "It will be added within " + Convert.ToInt32(publicationTime.Days).ToString() + " days ago";
                    }

                    return "It will be added within " + Convert.ToInt32(publicationTime.Hours).ToString() + " hours ago ";
                }
                else
                {
                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        return "Last added " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        return "Last added " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " months ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        return "Last added " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " days ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        return "Last added " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago.";
                    }

                    return "Last added " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago.";
                }
            }
            else
            {
                return "Last added 1 days ago";
            }
        }

        public string GetBlockPupInfo(DateTime blockDate)
        {
            return "Bloqueado " + blockDate.ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-ES"));
        }

        public string GetCreationInfoPupEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                string[] validformats = ["MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss","yyyy-MM-dd HH:mm:ss, fff",
                                                    "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt"];

                CultureInfo provider = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(millisecondTime, validformats, provider,
                                            DateTimeStyles.None, out creationDate))
                {
                }

                else
                {
                    try
                    {
                        string fecharemove = millisecondTime;

                        if (millisecondTime.ToString().Contains("a. m."))
                        {
                            fecharemove = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if (millisecondTime.ToString().Contains("p. m."))
                        {
                            fecharemove = Regex.Replace(millisecondTime, "p. m.", "PM");
                        }
                        else if (millisecondTime.ToString().Contains("a."))
                        {
                            string[] auxfecha = millisecondTime.Trim().ToString().Split(' ');
                            fecharemove = auxfecha[0] + " " + auxfecha[1];
                        }
                        else if (millisecondTime.ToString().Contains("p."))
                        {
                            string[] auxfecha = millisecondTime.Trim().ToString().Split(' ');
                            fecharemove = auxfecha[0] + " " + auxfecha[1] + " PM";
                        }
                        else if (millisecondTime.ToString().Contains("-"))
                        {
                            string[] auxfecha = millisecondTime.Trim().ToString().Split(' ');
                            string[] auxhora = auxfecha[1].Trim().ToString().Split(':');
                            fecharemove = auxfecha[0] + " " + auxhora[0] + ":" + auxhora[1];
                        }

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                var publicationDate = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("es-CO"));

                return publicationDate;
            }
            else
            {
                return "Date don't exists.";
            }
        }

        public DateTime CreateServerDate()
        {
            var dateServer = DateTime.Now.AddHours(-5);

            return dateServer;
        }
    }
}
