using ExchangeOffice.Models;

namespace ExchangeOffice.Presenters.Views
{
    public interface IOperationHistoryView : IBaseView
    {
        public IEnumerable<OperationHistoryModelView> operations { get; set; }
    }
}
