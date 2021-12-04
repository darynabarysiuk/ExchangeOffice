using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.Presenters
{
    public class MainPresenter : ViewPresenterBase<IMainView>
    {
        public delegate MainPresenter Factory(IMainView view);

        public MainPresenter(IMainView view) : base(view)
        {
        }

        public override void InitView()
        {
        }
    }
}
