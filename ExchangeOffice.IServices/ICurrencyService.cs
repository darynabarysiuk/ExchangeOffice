using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface ICurrencyService
    {
        public ICollection<Currency> GetCurrencies();
    }
}
