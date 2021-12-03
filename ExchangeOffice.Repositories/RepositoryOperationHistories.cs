using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;

namespace ExchangeOffice.Repositories
{
    public class RepositoryOperationHistories : BaseRepository<OperationHistory>, IRepositoryOperationHistories
    {
        public RepositoryOperationHistories(ApplicationContext context) : base(context)
        {
        }
    }
}
