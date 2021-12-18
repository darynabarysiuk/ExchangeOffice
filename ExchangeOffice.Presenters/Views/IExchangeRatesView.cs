using ExchangeOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters.Views
{
    public interface IExchangeRatesView : IBaseView
    {
        event EventHandler SetCurrencyRate;

        string SelectedCurrencyTo { get; }

        string SelectedCurrencyFrom { get; }

        string ValueForCurrencyRate { get; set; }

        IEnumerable<Currency> CurrencyList { get; set; }

        event EventHandler OkClick;
    }
}
