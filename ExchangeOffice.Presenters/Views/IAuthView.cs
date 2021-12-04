
namespace ExchangeOffice.Presenters.Views
{
    public interface IAuthView
    {
        string Login { get; }

        string Password { get; }

        public bool UserSuccessfullyAuthenticated { get; set; }

        event EventHandler AuthClicked;

        void ToMainForm();

        void ShowError(string error);
    }
}
