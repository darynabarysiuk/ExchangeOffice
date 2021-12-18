using Aspose.Pdf;
using ExchangeOffice.Entities;

namespace ExchangeOffice.Presenters.Views
{
    public interface IHandlingClientView : IBaseView
    {
        string SelectedCurrencyTo { get; }

        string SelectedCurrencyFrom { get; }

        string TextValueFrom { get; set; }

        string TextValueTo { get; set; }

        IEnumerable<Currency> CurrencyList { get; set; }

        event EventHandler SetCurrencyRate;

        event EventHandler OperateClick;

        event EventHandler TextFromChanged;

        event EventHandler TextToChanged;

        public void ShowDialogWithCheckQuestion(Document check);
    }
}
