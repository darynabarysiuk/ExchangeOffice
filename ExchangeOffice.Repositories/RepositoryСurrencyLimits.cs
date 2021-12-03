using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;

namespace ExchangeOffice.Repositories
{
    public class RepositoryСurrencyLimits : BaseRepository<СurrencyLimit>, IRepositoryСurrencyLimits
    {
        public RepositoryСurrencyLimits(ApplicationContext context) : base(context)
        {
        }
    }
}
