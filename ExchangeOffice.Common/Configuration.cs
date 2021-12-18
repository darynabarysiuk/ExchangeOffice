using System.Configuration;

namespace ExchangeOffice.Common
{
    public class Configuration
    {
        public static string? ConnectionString => ConfigurationManager.ConnectionStrings["sqlString"].ToString();

        public static DateTime CurrentDate
        {
            get
            {
                var currentDateString = ConfigurationManager.AppSettings["currentDate"];
                if (currentDateString == null)
                {
                    return DateTime.Now.Date;
                }
                return DateTime.Parse(currentDateString);
            }
            set
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings["currentDate"] == null)
                {
                    settings.Add("currentDate", value.Date.ToString());
                }
                else
                {
                    settings["currentDate"].Value = value.Date.ToString();
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }
    }
}
