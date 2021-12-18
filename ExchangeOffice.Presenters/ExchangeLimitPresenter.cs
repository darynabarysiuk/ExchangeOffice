using ExchangeOffice.IServices;
using ExchangeOffice.Presenters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters
{
    public class ExchangeLimitPresenter : ViewPresenterBase<IExchangeLimitView>
    {
        private readonly ICurrencyLimitService currencyLimitService;

        public delegate ExchangeLimitPresenter Factory(IExchangeLimitView view);

        public ExchangeLimitPresenter(IExchangeLimitView view, ICurrencyLimitService currencyLimitService) : base(view)
        {
            this.currencyLimitService = currencyLimitService;
        }

        public override void InitView()
        {
            view.CurrencyList = currencyLimitService.GetСurrencyLimits();
            view.OkClicked += View_OkClicked;
        }

        private void View_OkClicked(object? sender, EventArgs e)
        {
            if(view.NewValueForCurrencyLimit == "")
            {
                view.ShowError("Поле предела должно быть заполнено!");
                return;
            }
            var currencyLimit = view.CurrencyList
                .FirstOrDefault(e => e.Сurrency.ShortName == view.SelectedCurrencyShortName);
            var newCurrencyLimit = Convert.ToDouble(view.NewValueForCurrencyLimit);

            if (newCurrencyLimit <= 0)
            {
                view.ShowError("Предел введен неверно");
                return;
            }
            if (currencyLimit.Limit != newCurrencyLimit)
            {
                currencyLimitService.SetCurrencyLimit(currencyLimit.CurrencyID, newCurrencyLimit);
            }
            view.Close();
        }
    }
}
