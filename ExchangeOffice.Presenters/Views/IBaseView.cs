namespace ExchangeOffice.Presenters.Views
{
    public interface IBaseView
    {
        void ShowError(string error);

        void Close();
    }
}
