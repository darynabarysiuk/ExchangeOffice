using ExchangeOffice.IServices;
using ExchangeOffice.Presenters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters
{
    public class ExchangeRatesPresenter : ViewPresenterBase<IExchangeRatesView>
    {
        private readonly ICurrencyService currencyService;

        private readonly ICurrencyRateService currencyRateService;

        public delegate ExchangeRatesPresenter Factory(IExchangeRatesView view);

        public ExchangeRatesPresenter(IExchangeRatesView view, ICurrencyService currencyLimitService, ICurrencyRateService currencyRateService) : base(view)
        {
            this.currencyService = currencyLimitService;
            this.currencyRateService = currencyRateService;
        }

        public override void InitView()
        {
            view.SetCurrencyRate += View_SetCurrencyRate;
            view.CurrencyList = currencyService.GetCurrencies();
            view.OkClick += View_OkClick;
        }

        private void View_SetCurrencyRate(object? sender, EventArgs e)
        {
            var currencyTo = currencyService.GetCurrencyByShortName(view.SelectedCurrencyTo);
            var currencyFrom = currencyService.GetCurrencyByShortName(view.SelectedCurrencyFrom);
            view.ValueForCurrencyRate = currencyRateService.GetCurrencyRate(currencyFrom.ID, currencyTo.ID)?.Value.ToString();
        }

        private void View_OkClick(object? sender, EventArgs e)
        {

            if (view.ValueForCurrencyRate == "")
            {
                view.ShowError("Поле должно быть заполнено!");
                return;
            }

            var newCurrencyRateValue = Convert.ToDouble(view.ValueForCurrencyRate);

            if (newCurrencyRateValue <= 0)
            {
                view.ShowError("Значение введено неверно");
                return;
            }

            var currencyTo = currencyService.GetCurrencyByShortName(view.SelectedCurrencyTo);
            var currencyFrom = currencyService.GetCurrencyByShortName(view.SelectedCurrencyFrom);
            var currencyRate = currencyRateService.GetCurrencyRate(currencyFrom.ID, currencyTo.ID);

            if(currencyRate.Value != newCurrencyRateValue)
            {
                currencyRate.Value = newCurrencyRateValue;
                currencyRateService.ChangeCurrencyRate(currencyRate);
            }
            view.Close();
        }
    }
}
