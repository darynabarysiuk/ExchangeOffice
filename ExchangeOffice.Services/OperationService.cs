using ExchangeOffice.Entities;
using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class OperationService : IOperationService
    {
        private readonly IRepositoryOperationHistories repositoryOperationHistories;

        public OperationService(IRepositoryOperationHistories repositoryOperationHistories)
        {
            this.repositoryOperationHistories = repositoryOperationHistories;
        }

        public async Task<OperationHistory> AddOperation(OperationHistory operationHistory)
        {
            return await repositoryOperationHistories.CreateAsync(operationHistory);
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

        public OperationHistory GetOperationByID(int id)
        {
            var operation = repositoryOperationHistories.GetAllByQueryable(
                p => p.ID == id,
                p => p.CurrencyRate,
                p => p.CurrencyRate.CurrencyFrom,
                p => p.CurrencyRate.CurrencyTo
            ).FirstOrDefault();

            return operation;
        }

    }
}
