using System.Configuration;

namespace ExchangeOffice.Common
{
    public class Configuration
    {
        public static string? ConnectionString => ConfigurationManager.ConnectionStrings[0].ConnectionString;

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
                ConfigurationManager.AppSettings.Set("currentDate", value.Date.ToString());
            }
        }
    }
}
