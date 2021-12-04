using ExchangeOffice.IServices;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.Presenters
{
    public class AuthPresenter : ViewPresenterBase<IAuthView>
    {
        public delegate AuthPresenter Factory(IAuthView view);

        private readonly IAuthService authService;

        public AuthPresenter(IAuthView view, IAuthService authService) : base(view)
        {
            this.authService = authService;
            view.AuthClicked += new EventHandler(View_AuthClicked);
        }

        private void View_AuthClicked(object? sender, EventArgs e)
        {
            var result = authService.Authentificate(view.Login, view.Password).Result;
            if(result)
            {
                view.ToMainForm();
            }
            else
            {
                view.ShowError("Пользователь не найден!");
            }
        }

        public override void InitView()
        {}
    }
}
