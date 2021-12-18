using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface ICurrencyService
    {
        ICollection<Currency> GetCurrencies();

        Currency GetCurrencyByShortName(string shortName);
    }
}
