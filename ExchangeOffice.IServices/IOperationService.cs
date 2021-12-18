using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface IOperationService
    {
        public Task<OperationHistory> AddOperation(OperationHistory operationHistory);

        public ICollection<OperationHistory> GetOperationHistory();

        public OperationHistory GetOperationByID(int id);
    }
}
