using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepositoryCurrencies repositoryCurrencies;

        public CurrencyService(IRepositoryCurrencies repositoryCurrencies)
        {
           this.repositoryCurrencies = repositoryCurrencies;
        }

        public ICollection<Currency> GetCurrencies()
        {
            return repositoryCurrencies.GetAllQueryable().ToList();
        }
    }
}
