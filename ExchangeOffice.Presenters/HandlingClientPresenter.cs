using ExchangeOffice.Entities;
using ExchangeOffice.IServices;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.Presenters
{
    public class HandlingClientPresenter : ViewPresenterBase<IHandlingClientView>
    {
        private readonly ICurrencyService currencyService;

        private readonly ICurrencyRateService currencyRateService;

        private readonly IOperationService operationService;

        private readonly IDateTimeService dateTimeService;

        private readonly ICurrencyLimitService currencyLimitService;

        private readonly ICheckService checkService;

        public delegate HandlingClientPresenter Factory(IHandlingClientView view);

        public HandlingClientPresenter(
            IHandlingClientView view, 
            ICurrencyService currencyService, 
            ICurrencyRateService currencyRateService, 
            IOperationService operationService, 
            IDateTimeService dateTimeService,
            ICurrencyLimitService currencyLimitService,
            ICheckService checkService
        ) : base(view) 
        {
            this.currencyService = currencyService;
            this.currencyRateService = currencyRateService;
            this.operationService = operationService;
            this.dateTimeService = dateTimeService;
            this.currencyLimitService = currencyLimitService;
            this.checkService = checkService;
            view.OperateClick += Operate;
            view.TextFromChanged += View_TextFromChanged;
            view.TextToChanged += View_TextToChanged;
        }

        private void Operate(object? sender, EventArgs e)
        {
            var count = Convert.ToDouble(view.TextValueFrom);
            if (view.TextValueFrom == null || view.TextValueFrom == "" || count <= 0)
            {
                view.ShowError("Введено неверное количество денег");
                return;
            }
            var currencyFrom = currencyService.GetCurrencyByShortName(view.SelectedCurrencyFrom);
            var limitValue = currencyLimitService.GetCurrencyLimit(currencyFrom.ID);
            if(limitValue != null && limitValue < count)
            {
                view.ShowError("Привышен лимит равный: " + limitValue.ToString());
                return;
            }
            var currencyTo = currencyService.GetCurrencyByShortName(view.SelectedCurrencyTo);
            var currencyRate = currencyRateService.GetCurrencyRate(currencyFrom.ID, currencyTo.ID);


            var operation = new OperationHistory
            {
                Value = Convert.ToDouble(view.TextValueFrom),
                DateTime = dateTimeService.GetCurrentDateTime,
                CurrencyRateID = currencyRate.ID
            };

            operation = Task.Run(() => operationService.AddOperation(operation)).Result;

            operation = operationService.GetOperationByID(operation.ID);
            var check = checkService.GenerateCheck(operation);
            view.ShowDialogWithCheckQuestion(check);
        }

        public override void InitView()
        {
            view.CurrencyList = currencyService.GetCurrencies();
        }

        private void View_TextFromChanged(object? sender, EventArgs e)
        {
            if(view.TextValueFrom == null || view.TextValueFrom == "")
            {
                view.TextValueTo = "";
                return;
            }
            var currencyTo = currencyService.GetCurrencyByShortName(view.SelectedCurrencyTo);
            var currencyFrom = currencyService.GetCurrencyByShortName(view.SelectedCurrencyFrom);
            var currencyRateValue = currencyRateService.GetCurrencyRate(currencyFrom.ID, currencyTo.ID)?.Value;
            view.TextToChanged -= View_TextToChanged;
            view.TextValueTo = (Convert.ToDouble(view.TextValueFrom) / currencyRateValue).ToString();
            view.TextToChanged += View_TextToChanged;
        }

        private void View_TextToChanged(object? sender, EventArgs e)
        {
            if (view.TextValueTo == null || view.TextValueTo == "")
            {
                view.TextValueFrom = "";
                return;
            }
            var currencyTo = currencyService.GetCurrencyByShortName(view.SelectedCurrencyTo);
            var currencyFrom = currencyService.GetCurrencyByShortName(view.SelectedCurrencyFrom);
            var currencyRateValue = currencyRateService.GetCurrencyRate(currencyFrom.ID, currencyTo.ID)?.Value;
            view.TextFromChanged -= View_TextFromChanged;
            view.TextValueFrom = (Convert.ToDouble(view.TextValueTo) * currencyRateValue).ToString();
            view.TextFromChanged += View_TextFromChanged;
        }
    }
}
