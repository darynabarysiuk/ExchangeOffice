
namespace ExchangeOffice.Presenters.Views
{
    public interface IAuthView : IBaseView
    {
        string Login { get; }

        string Password { get; }

        public bool UserSuccessfullyAuthenticated { get; set; }

        event EventHandler AuthClicked;

        void ToMainForm();
    }
}
