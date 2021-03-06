using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly IRepositoryCurrencyRates repositoryCurrencyRates;
        private readonly IDateTimeService dateTimeService;

        public CurrencyRateService(IRepositoryCurrencyRates repositoryCurrencyRates, IDateTimeService dateTimeService)
        {
            this.repositoryCurrencyRates = repositoryCurrencyRates;
            this.dateTimeService = dateTimeService;
        }

        public async Task<bool> ChangeCurrencyRate(CurrencyRate updatedCurrencyRate)
        {
            var currentDate = dateTimeService.GetCurrentDateTime.Date;
            var any = repositoryCurrencyRates.GetAllQueryable()
                .Where(
                    p => p.ID == updatedCurrencyRate.ID &&
                    p.DateTime.Date == currentDate
                ).Any();

            if(any)
            {
                await repositoryCurrencyRates.UpdateAsync(updatedCurrencyRate);
            }
            else
            {
                updatedCurrencyRate.DateTime = currentDate;
                updatedCurrencyRate.ID = default(int);
                await repositoryCurrencyRates.CreateAsync(updatedCurrencyRate);
            }

            return true;
        }

        public CurrencyRate? GetCurrencyRate(int CurrencyIDFrom, int CurrencyIDTo)
        {
            var value = repositoryCurrencyRates.GetAllQueryable()
                .Where(
                    p => p.CurrencyIDFrom == CurrencyIDFrom &&
                    p.CurrencyIDTo == CurrencyIDTo
                ).OrderByDescending(p => p.DateTime)
                .FirstOrDefault();

            return value;
        }
    }
}
