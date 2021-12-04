namespace ExchangeOffice.IServices
{
    public interface ICurrencyLimitService
    {
        double? GetCurrencyLimit(int CurrencyID);

        Task<bool> SetCurrencyLimit(int CurrencyID, double newLimit);
    }
}
