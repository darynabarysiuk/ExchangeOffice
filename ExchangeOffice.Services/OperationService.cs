using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IService;

namespace ExchangeOffice.Services
{
    public class OperationService : IOperationService
    {
        private readonly IRepositoryOperationHistories repositoryOperationHistories;

        public OperationService(IRepositoryOperationHistories repositoryOperationHistories)
        {
            this.repositoryOperationHistories = repositoryOperationHistories;
        }

        public async Task<bool> AddOperation(OperationHistory operationHistory)
        {
            return await repositoryOperationHistories.CreateAsync(operationHistory) != null;
        }

        public ICollection<OperationHistory> GetOperationHistory()
        {
            var operations = repositoryOperationHistories.GetAllByQueryable(
                p => true, 
                p => p.CurrencyRate, 
                p => p.CurrencyRate.CurrencyFrom, 
                p => p.CurrencyRate.CurrencyTo
            ).ToList();

            return operations;
        }
    }
}
