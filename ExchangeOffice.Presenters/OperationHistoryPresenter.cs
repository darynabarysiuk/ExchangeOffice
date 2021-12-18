using ExchangeOffice.IServices;
using ExchangeOffice.Models;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.Presenters
{
    public class OperationHistoryPresenter : ViewPresenterBase<IOperationHistoryView>
    {
        private readonly IOperationService operationService;

        public delegate OperationHistoryPresenter Factory(IOperationHistoryView view);


        public OperationHistoryPresenter(IOperationHistoryView view, IOperationService operationService) 
            : base(view)
        {
            this.operationService = operationService;
        }

        public override void InitView()
        {
            view.operations = operationService.GetOperationHistory().Select((operationHistory) =>
            {
                return new OperationHistoryModelView
                {
                    Value = operationHistory.Value,
                    DateTime = operationHistory.DateTime,
                    ShortNameFrom = operationHistory.CurrencyRate.CurrencyFrom.ShortName,
                    ShortNameTo = operationHistory.CurrencyRate.CurrencyTo.ShortName,
                    CurrencyValue = operationHistory.CurrencyRate.Value
                };
            });
        }
    }
}
