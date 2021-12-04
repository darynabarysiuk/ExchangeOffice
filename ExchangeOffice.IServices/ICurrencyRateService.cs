using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface ICurrencyRateService
    {
        Task<bool> ChangeCurrencyRate(CurrencyRate updatedCurrencyRate);

        double? GetCurrencyRateValue(int CurrencyIDFrom, int CurrencyIDTo);
    }
}
