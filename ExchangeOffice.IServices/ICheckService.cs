using Aspose.Pdf;
using ExchangeOffice.Entities;

namespace ExchangeOffice.IServices
{
    public interface ICheckService
    {
        Document GenerateCheck(OperationHistory operationHistory);
    }
}
