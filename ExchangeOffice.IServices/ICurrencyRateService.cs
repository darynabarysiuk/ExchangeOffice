using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface ICurrencyRateService
    {
        Task<bool> ChangeCurrencyRate(CurrencyRate updatedCurrencyRate);

        CurrencyRate? GetCurrencyRate(int CurrencyIDFrom, int CurrencyIDTo);
    }
}
