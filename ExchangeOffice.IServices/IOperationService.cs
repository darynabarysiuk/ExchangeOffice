using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface IOperationService
    {
        public Task<bool> AddOperation(OperationHistory operationHistory);

        public ICollection<OperationHistory> GetOperationHistory();
    }
}
