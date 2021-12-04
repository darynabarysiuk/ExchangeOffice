using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class CurrencyLimitService : ICurrencyLimitService
    {
        private readonly IRepositoryСurrencyLimits repositoryСurrencyLimits;

        public CurrencyLimitService(IRepositoryСurrencyLimits repositoryСurrencyLimits)
        {
            this.repositoryСurrencyLimits = repositoryСurrencyLimits;
        }

        public double? GetCurrencyLimit(int CurrencyID)
        {
            var value = repositoryСurrencyLimits.GetAllQueryable()
                .Where(
                    p => p.CurrencyID == CurrencyID
                ).FirstOrDefault()?.Limit;

            return value;
        }

        public async Task<bool> SetCurrencyLimit(int CurrencyID, double newLimit)
        {
            var сurrencyLimit = repositoryСurrencyLimits.GetAllQueryable()
                .Where(
                    p => p.CurrencyID == CurrencyID
                ).FirstOrDefault();

            if (сurrencyLimit != null)
            {
                сurrencyLimit.Limit = newLimit;
                await repositoryСurrencyLimits.UpdateAsync(сurrencyLimit);
            }
            else
            {
                сurrencyLimit = new СurrencyLimit {
                    Limit = newLimit,
                    CurrencyID = CurrencyID
                };
                await repositoryСurrencyLimits.CreateAsync(сurrencyLimit);
            }

            return true;
        }
    }
}
