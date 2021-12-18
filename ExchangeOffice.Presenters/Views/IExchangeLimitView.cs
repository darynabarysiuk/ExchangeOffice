using ExchangeOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters.Views
{
    public interface IExchangeLimitView : IBaseView
    {
        IEnumerable<СurrencyLimit> CurrencyList { get; set; }

        event EventHandler OkClicked;

        public string SelectedCurrencyShortName { get; }

        public string NewValueForCurrencyLimit { get; }
    }
}
