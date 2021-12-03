using System.Configuration;

namespace ExchangeOffice.Common
{
    public class Configuration
    {
        public static string? ConnectionString => ConfigurationManager.AppSettings["connectionString"];
    }
}
