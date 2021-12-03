using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;

namespace ExchangeOffice.Repositories
{
    public class RepositoryCashers : BaseRepository<Casher>, IRepositoryCashers
    {
        public RepositoryCashers(ApplicationContext context) : base(context)
        {
        }
    }
}
