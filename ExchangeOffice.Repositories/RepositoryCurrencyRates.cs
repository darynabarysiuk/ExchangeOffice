using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;

namespace ExchangeOffice.Repositories
{
    public class RepositoryCurrencyRates : BaseRepository<CurrencyRate>, IRepositoryCurrencyRates
    {
        public RepositoryCurrencyRates(ApplicationContext context) : base(context)
        {
        }
    }
}
