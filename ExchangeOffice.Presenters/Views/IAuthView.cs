
namespace ExchangeOffice.Presenters.Views
{
    public interface IAuthView
    {
        string Login { get; }

        string Password { get; }

        event EventHandler AuthClicked;

        void ToMainForm();

        void ShowError(string error);
    }
}
