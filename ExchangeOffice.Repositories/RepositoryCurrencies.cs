using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;

namespace ExchangeOffice.Repositories
{
    public class RepositoryCurrencies : BaseRepository<Currency>, IRepositoryCurrencies
    {
        public RepositoryCurrencies(ApplicationContext context) : base(context)
        {
        }
    }
}
