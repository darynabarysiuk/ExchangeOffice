using ExchangeOffice.Entities;

namespace ExchangeOffice.IService
{
    public interface IOperationService
    {
        public Task<bool> AddOperation(OperationHistory operationHistory);

        public ICollection<OperationHistory> GetOperationHistory();
    }
}
