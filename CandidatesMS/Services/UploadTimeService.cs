using CandidatesMS.Persistence.Entities;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IUploadTimeService
    {
        public string GetPublicationInfo(string millisecondTime);
        public string GetPublicationInfoEnglish(string millisecondTime);
        public string GetPublicationEnglish(string millisecondTime);
        public string GetPublicationInfoWithoutPrefix(string millisecondTime);
        public string GetCandidateCreationInfo(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, int candidateCompanyUserId, int companyUserId);
        public string GetCandidateCreationInfoEnglish(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, int candidateCompanyUserId, int companyUserId);
        public string GetCandidateCreationInfoMaster(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, string companyUserName);
        public string GetCandidateCreationInfoMasterEnglish(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, string companyUserName);
        public string GetCandidateCreationShortInfo(string millisecondTime, int migrated, string source);
        public string GetNoteCreationInfo(string millisecondTime);
        public string GetNoteCreationShortInfo(string millisecondTime);
        public string GetFileTypeCreationInfoPup(string millisecondTime);
        public string GetFileTypeCreationInfoPupEnglish(string millisecondTime);
        public string GetFileTypeCreationShortInfo(string millisecondTime);
        public string GetEditInfo(string millisecondTime);
        public string GetCreationDate(string millisecondTime);
        public string GetCreationDateEnglish(string millisecondTime);
        public string GetFormatColombian(string millisecondTime);
        public string GetFormatUsa(string millisecondTime);
        public string GetBlockInfo(DateTime blockDate);
        public string GetBlockPupInfo(DateTime blockDate);
        public DateTime GetDateWithString(string millisecondTime);
    }

    public class UploadTimeService : IUploadTimeService
    {
        private IMatchServerDate _matchServerDate;

        public UploadTimeService(IMatchServerDate matchServerDate)
        {
            _matchServerDate = matchServerDate;
        }
        public string GetPublicationInfo(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;
        
                else
                {
                    try
                    {
                        string fecharemove = millisecondTime;

                        if(millisecondTime.ToString().Contains("a. m."))
                        {
                            fecharemove = Regex.Replace(millisecondTime, "a. m.", "AM");
                        }
                        else if(millisecondTime.ToString().Contains("p. m.")){
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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());                  
                    }
                    catch (Exception  ex)
                    {

                       ex.Message.ToString();
                    }             
                }

                var publicationDate = Convert.ToDateTime(creationDate);

                //var publicationTime = publicationDate - DateTime.Now;

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = publicationDate - dateTimeServer;

                if (publicationTime.Hours > 0)
                {
                    if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                    {
                        return "Se subirá dentro de " + Convert.ToInt32(publicationTime.Days).ToString() + " días.";
                    }
                    return "Se subirá dentro de " + Convert.ToInt32(publicationTime.Hours).ToString() + " horas.";
                }
                else
                {
                    //if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    //{
                    //    return "Subido hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    //}
                    //return "Subido hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        return "Subido hace " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        return "Subido hace " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        return "Subido hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        return "Subido hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                    }
                    return "Subido hace " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                }
            }
            else
            {
                return "Subido hace 1 día.";
            }
        }


        public string GetPublicationInfoEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                var publicationDate = Convert.ToDateTime(creationDate);

                //var publicationTime = publicationDate - DateTime.Now;

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = publicationDate - dateTimeServer;

                if (publicationTime.Hours > 0)
                {
                    if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                    {
                        return "It will be uploaded within " + Convert.ToInt32(publicationTime.Days).ToString() + " days ago";
                    }
                    return "It will be uploaded within " + Convert.ToInt32(publicationTime.Hours).ToString() + " hours ago ";
                }
                else
                {
                    //if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    //{
                    //    return "Subido hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    //}
                    //return "Subido hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        return "Uploaded " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        return "Uploaded " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " months ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        return "Uploaded " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " days ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        return "Uploaded " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago.";
                    }
                    return "Uploaded " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago.";
                }
            }
            else
            {
                return "Uploaded 1 days ago";
            }
        }

        public string GetPublicationEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                var publicationDate = Convert.ToDateTime(creationDate);

                //var publicationTime = publicationDate - DateTime.Now;

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = publicationDate - dateTimeServer;

                if (publicationTime.Hours > 0)
                {
                    if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                    {
                        return Convert.ToInt32(publicationTime.Days).ToString() + " days ago";
                    }
                    return Convert.ToInt32(publicationTime.Hours).ToString() + " hours ago ";
                }
                else
                {
                    //if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    //{
                    //    return "Subido hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    //}
                    //return "Subido hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " months ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        return Convert.ToInt32(publicationTime.Days * -1).ToString() + " days ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago.";
                    }
                    return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago.";
                }
            }
            else
            {
                return "1 days ago";
            }
        }




        public string GetPublicationInfoWithoutPrefix(string millisecondTime)
        {
            try
            {
                if (!string.IsNullOrEmpty(millisecondTime))
                {
                    var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                    var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);

                    if (publicationTime.Hours > 0)
                    {
                        if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                        {
                            return "dentro de " + Convert.ToInt32(publicationTime.Days).ToString() + " días.";
                        }
                        return "dentro de " + Convert.ToInt32(publicationTime.Hours).ToString() + " horas.";
                    }
                    else
                    {
                        //if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                        //{
                        //    return "hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                        //}
                        //return "hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                        if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                        {
                            return "Subido hace " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                        {
                            return "Subido hace " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                        {
                            return "Subido hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                        {
                            return "Subido hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                        }
                        return "Subido hace " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                    }
                }
                else
                {
                    return "hace 0 días.";
                }
            }
            catch (Exception)
            {

                return "hace 0 días.";
            }
        }

        public string GetCandidateCreationInfo(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, int candidateCompanyUserId, int companyUserId)
        {
            try
            {
                string creationInfo = "";

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();

                if (migrated == 0)
                {
                    creationInfo = "Agregado de portal hace ";
                    if (source != "" && source != null)
                        creationInfo = "Agregado de portal via " + source + " hace ";
                }
                else if (migrated == 1)
                    creationInfo = "Agregado manualmente via migración hace ";
                else if (migrated == 3)
                    creationInfo = "Agregado por Bot Comercial hace ";
                else if (migrated == 4)
                {
                    if (nameMember != String.Empty)
                        creationInfo = "Agregado manualmente vía análisis por " + nameMember + " hace ";
                    else
                        creationInfo = "Agregado manualmente vía análisis hace ";
                }
                else
                {
                    if (nameMember != String.Empty)
                        creationInfo = "Agregado manualmente por " + nameMember + " hace ";
                    else
                        creationInfo = "Agregado manualmente hace ";
                }

                try
                {
                    var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                    var publicationTime = publicationDate - dateTimeServer;

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                    }

                    var firstLoginDate = Convert.ToDateTime(millisecondFirstLoginTime).ToLocalTime();

                    dateTimeServer = _matchServerDate.GetDateTimeByServer();

                    var firstLoginTime = firstLoginDate - dateTimeServer;

                    if (migrated != 0 && isFromCompanyAndLogin)
                    {
                        if (candidateCompanyUserId != companyUserId)
                            creationInfo = "";

                        creationInfo += " Registrado en portal hace ";

                        if (Convert.ToInt32(firstLoginTime.TotalDays * -1) > 365.25)
                        {
                            creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 365.25).ToString() + " años.";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalDays * -1)) > 30.637)
                        {
                            creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 30.637).ToString() + " meses.";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalHours * -1)) > 24)
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Days * -1).ToString() + " días.";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalMinutes * -1)) > 60)
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Hours * -1).ToString() + " horas.";
                        }
                        else
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Minutes * -1).ToString() + " minutos.";
                        }
                    }
                }
                catch(Exception ex)
                {

                }

                return creationInfo;
            }
            catch (Exception ex)
            {

                return "Hace 0 dias.";
            }
        }

        public string GetCandidateCreationInfoEnglish(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, int candidateCompanyUserId, int companyUserId)
        {
            try
            {
                string creationInfo = "";

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();

                if (migrated == 0)
                {
                    creationInfo = "Added from portal ";
                    if (source != "" && source != null)
                        creationInfo = "Added from portal via " + source + " ";
                }
                else if (migrated == 1)
                    creationInfo = "Added manually via migration ";
                else if (migrated == 3)
                    creationInfo = "Added by Commercial Bot ";
                else if (migrated == 4)
                {
                    if (nameMember != String.Empty)
                        creationInfo = "Manually added via analysis by " + nameMember + ", ";
                    else
                        creationInfo = "Manually added via migration ";
                }
                else
                {
                    if (nameMember != String.Empty)
                        creationInfo = "Manually added by " + nameMember + ", ";
                    else
                        creationInfo = "Manually added ";
                }

                try
                {
                    var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                    var publicationTime = publicationDate - dateTimeServer;

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " months ago";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Days * -1).ToString() + " days ago";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago";
                    }

                    var firstLoginDate = Convert.ToDateTime(millisecondFirstLoginTime).ToLocalTime();

                    dateTimeServer = _matchServerDate.GetDateTimeByServer();

                    var firstLoginTime = firstLoginDate - dateTimeServer;

                    if (migrated != 0 && isFromCompanyAndLogin)
                    {
                        if (candidateCompanyUserId != companyUserId)
                            creationInfo = "";

                        creationInfo += " Registered portal ";

                        if (Convert.ToInt32(firstLoginTime.TotalDays * -1) > 365.25)
                        {
                            creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 365.25).ToString() + " years ago";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalDays * -1)) > 30.637)
                        {
                            creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 30.637).ToString() + " months ago";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalHours * -1)) > 24)
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Days * -1).ToString() + " days ago";
                        }
                        else if (Convert.ToInt32((firstLoginTime.TotalMinutes * -1)) > 60)
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Hours * -1).ToString() + " hours ago";
                        }
                        else
                        {
                            creationInfo += Convert.ToInt32(firstLoginTime.Minutes * -1).ToString() + " minutes ago";
                        }
                    }
                }
                catch(Exception ex)
                {

                }

                return creationInfo;
            }
            catch (Exception ex)
            {

                return "0 days ago";
            }
        }

        public string GetCandidateCreationInfoMaster(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, string companyUserName)
        {
            try
            {
                string creationInfo="";
                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                if (migrated == 0)
                {
                    creationInfo = "Agregado de portal hace ";
                    if (source != "" && source != null)
                        creationInfo = "Agregado de portal via " + source + " hace ";
                    var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                    //var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);
                    var publicationTime = publicationDate - dateTimeServer;

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                    }

                }



                var firstLoginDate = Convert.ToDateTime(millisecondFirstLoginTime).ToLocalTime();
                var firstLoginTime = firstLoginDate - dateTimeServer;

                if (migrated != 0 && isFromCompanyAndLogin)
                {
                    creationInfo += " Registrado en portal hace ";

                    if (Convert.ToInt32(firstLoginTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 365.25).ToString() + " años.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 30.637).ToString() + " meses.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Days * -1).ToString() + " días.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Hours * -1).ToString() + " horas.";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Minutes * -1).ToString() + " minutos.";
                    }

                    creationInfo += " Empresa " + companyUserName + ".";
                }

                return creationInfo;
            }
            catch (Exception ex)
            {

                return "Hace 0 dias.";
            }
        }

        public string GetCandidateCreationInfoMasterEnglish(string millisecondTime, string millisecondFirstLoginTime, int migrated, string source, string nameMember, bool isFromCompanyAndLogin, string companyUserName)
        {
            try
            {
                string creationInfo = "";
                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                if (migrated == 0)
                {
                    creationInfo = "Added from portal ";

                    if (source != "" && source != null)
                        creationInfo = "Added from portal via " + source;

                    var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                    //var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);
                    var publicationTime = publicationDate - dateTimeServer;

                    if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Days * -1).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago.";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago.";
                    }

                }



                var firstLoginDate = Convert.ToDateTime(millisecondFirstLoginTime).ToLocalTime();
                var firstLoginTime = firstLoginDate - dateTimeServer;

                if (migrated != 0 && isFromCompanyAndLogin)
                {
                    creationInfo += " registered portal ";

                    if (Convert.ToInt32(firstLoginTime.TotalDays * -1) > 365.25)
                    {
                        creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 365.25).ToString() + " years ago.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalDays * -1)) > 30.637)
                    {
                        creationInfo += Convert.ToInt32((firstLoginTime.Days * -1) / 30.637).ToString() + " months ago.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalHours * -1)) > 24)
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Days * -1).ToString() + " days ago.";
                    }
                    else if (Convert.ToInt32((firstLoginTime.TotalMinutes * -1)) > 60)
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Hours * -1).ToString() + " hours ago.";
                    }
                    else
                    {
                        creationInfo += Convert.ToInt32(firstLoginTime.Minutes * -1).ToString() + " minutes ago.";
                    }

                    creationInfo += " Company " + companyUserName + ".";
                }

                return creationInfo;
            }
            catch (Exception ex)
            {

                return "Hace 0 dias.";
            }
        }

        public string GetCandidateCreationShortInfo(string millisecondTime, int migrated, string source)
        {
            try
            {
                var publicationDate = Convert.ToDateTime(millisecondTime).ToLocalTime();

                //var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = publicationDate - dateTimeServer;

                if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " a.";
                }
                else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " m.";
                }
                else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                {
                    return Convert.ToInt32(publicationTime.Days * -1).ToString() + " d.";
                }
                else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                {
                    return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " h.";
                }
                return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " min.";
            }
            catch (Exception)
            {
                return "Hace 0 dias.";
            }
        }

        public string GetNoteCreationInfo(string millisecondTime)
        {
            DateTime publicationDate = DateTime.Now;
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

            if (DateTime.TryParseExact(millisecondTime, validformats, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out publicationDate)) ;
            else
            {
                publicationDate = Convert.ToDateTime(millisecondTime);
            }            

            string creationInfo = "Agregada hace ";

            //var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);

            var dateTimeServer = _matchServerDate.GetDateTimeByServer();
            var publicationTime = publicationDate - dateTimeServer;

            if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
            {
                return creationInfo + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
            }
            else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
            {
                return creationInfo + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
            }
            else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
            {
                return creationInfo + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
            }
            else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
            {
                return creationInfo + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
            }
            return creationInfo + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
        }

        public string GetNoteCreationShortInfo(string millisecondTime)
        {
            DateTime publicationDate = DateTime.Now;
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

            if (DateTime.TryParseExact(millisecondTime, validformats, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out publicationDate)) ;
            else
            {
                publicationDate = Convert.ToDateTime(millisecondTime);
            }            

            var dateTimeServer = _matchServerDate.GetDateTimeByServer();
            var publicationTime = publicationDate - dateTimeServer;

            if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
            {
                return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " a.";
            }
            else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
            {
                return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " m.";
            }
            else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
            {
                return Convert.ToInt32(publicationTime.Days * -1).ToString() + " d.";
            }
            else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
            {
                return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " h.";
            }
            return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " min.";
        }

        public string GetFileTypeCreationInfoPup(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;
                string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                if (DateTime.TryParseExact(millisecondTime, validformats, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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
                return "No existe fecha.";
            }


        }

        public string GetFileTypeCreationInfoPupEnglish(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;
                string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                if (DateTime.TryParseExact(millisecondTime, validformats, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }



                var publicationDate = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-US"));

                return publicationDate;
            }
            else
            {
                return "No existe fecha.";
            }
        }

        public string GetFileTypeCreationShortInfo(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                var publicationDate = Convert.ToDateTime(creationDate);

                //var publicationTime = publicationDate - DateTime.Now;

                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = publicationDate - dateTimeServer;

                if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " a.";
                }
                else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " m.";
                }
                else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                {
                    return Convert.ToInt32(publicationTime.Days * -1).ToString() + " d.";
                }
                else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                {
                    return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " h.";
                }
                return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " min.";
            }
            else
            {
                return "Subido hace 1 día.";
            }
        }

        public string GetEditInfo(string millisecondTime)
        {
            var publicationDate = Convert.ToDateTime(millisecondTime);

            //var publicationTime = publicationDate - DateTime.Now;

            var dateTimeServer = DateTime.Now.AddHours(-5);
            var publicationTime = publicationDate - dateTimeServer;
            //var publicationTime = publicationDate - DateTime.Now.ToLocalTime();

            if (publicationTime.Hours > 0)
            {
                if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                {
                    return "Se editara dentro de " + Convert.ToInt32(publicationTime.Days).ToString() + " días.";
                }
                return "Se editara dentro de " + Convert.ToInt32(publicationTime.Hours).ToString() + " horas.";
            }
            else
            {
                if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                }
                else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                }
                else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                {
                    return Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                }
                else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                {
                    return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                }
                return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
            }
        }

        public string GetCreationDate(string millisecondTime)
        {
            try
            {
                if (!string.IsNullOrEmpty(millisecondTime))
                {
                    DateTime creationDate = DateTime.Now;
                    DateTime publicationDate = DateTime.Now;

                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                                    "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt"};

                    CultureInfo provider = CultureInfo.InvariantCulture;

                    if (DateTime.TryParseExact(millisecondTime, validformats, provider,
                                                DateTimeStyles.None, out publicationDate))
                    {
                    }

                    var publicationTime = publicationDate - _matchServerDate.GetDateTimeByServer();

                    if (publicationTime.Hours > 0)
                    {
                        if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                        {
                            return "dentro de " + Convert.ToInt32(publicationTime.Days).ToString() + " días.";
                        }
                        return "dentro de " + Convert.ToInt32(publicationTime.Hours).ToString() + " horas.";
                    }
                    else
                    {
                        if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                        {
                            return "Hace " + Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                        {
                            return "Hace " + Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                        {
                            return "Hace " + Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                        {
                            return "Hace " + Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                        }
                        return "Hace " + Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
                    }
                }
                else
                {
                    return "Hace 0 días";
                }
            }
            catch (Exception ex)
            {

                return "Hace 0 días";
            }
        }

        public string GetCreationDateEnglish(string millisecondTime)
        {
            try
            {
                if (!string.IsNullOrEmpty(millisecondTime))
                {
                    DateTime creationDate = DateTime.Now;
                    DateTime publicationDate = DateTime.Now;

                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                                    "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt"};

                    CultureInfo provider = CultureInfo.InvariantCulture;

                    if (DateTime.TryParseExact(millisecondTime, validformats, provider,
                                                DateTimeStyles.None, out publicationDate))
                    {
                    }

                    var publicationTime = publicationDate - _matchServerDate.GetDateTimeByServer();

                    if (publicationTime.Hours > 0)
                    {
                        if (Convert.ToInt32(publicationTime.TotalHours) > 24)
                        {
                            return "Within " + Convert.ToInt32(publicationTime.Days).ToString() + " days.";
                        }
                        return "Within" + Convert.ToInt32(publicationTime.Hours).ToString() + " hours.";
                    }
                    else
                    {
                        if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                        {
                            return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " years ago.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                        {
                            return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " months ago.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                        {
                            return Convert.ToInt32(publicationTime.Days * -1).ToString() + " days ago.";
                        }
                        else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                        {
                            return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " hours ago.";
                        }
                        return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutes ago.";
                    }
                }
                else
                {
                    return "0 days ago";
                }
            }
            catch (Exception ex)
            {

                return "0 days ago";
            }
        }

        public string GetFormatColombian(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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
                return "Hace 0 días.";
            }
        }

        public string GetFormatUsa(string millisecondTime)
        {
            if (!string.IsNullOrEmpty(millisecondTime))
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(millisecondTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;

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

                        creationDate = Convert.ToDateTime(fecharemove.Trim().ToString());
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }
                }

                var publicationDate = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-CO"));

                return publicationDate;
            }
            else
            {
                return "0 days ago";
            }
        }

        /**/

        public string GetBlockInfo(DateTime blockDate)
        {
            try
            {
                var dateTimeServer = _matchServerDate.GetDateTimeByServer();
                var publicationTime = blockDate - dateTimeServer;

                if (Convert.ToInt32(publicationTime.TotalDays * -1) > 365.25)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 365.25).ToString() + " años.";
                }
                else if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 30.637)
                {
                    return Convert.ToInt32((publicationTime.Days * -1) / 30.637).ToString() + " meses.";
                }
                else if (Convert.ToInt32((publicationTime.TotalHours * -1)) > 24)
                {
                    return Convert.ToInt32(publicationTime.Days * -1).ToString() + " días.";
                }
                else if (Convert.ToInt32((publicationTime.TotalMinutes * -1)) > 60)
                {
                    return Convert.ToInt32(publicationTime.Hours * -1).ToString() + " horas.";
                }
                return Convert.ToInt32(publicationTime.Minutes * -1).ToString() + " minutos.";
            }
            catch (Exception)
            {
                return "0 días.";
            }
        }

        public string GetBlockPupInfo(DateTime blockDate)
        {
            return "Bloqueado " + blockDate.ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-ES"));
        }

        /**/

        public DateTime GetDateWithString(string millisecondTime)
        {
            DateTime publicationDate = DateTime.Now;
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

            if (DateTime.TryParseExact(millisecondTime, validformats, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out publicationDate)) ;
            else
            {
                publicationDate = Convert.ToDateTime(millisecondTime);
            }            
            return publicationDate;
            
        }

    }
}

