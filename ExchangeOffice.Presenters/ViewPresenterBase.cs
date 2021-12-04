namespace ExchangeOffice.Presenters
{
    public abstract class ViewPresenterBase<TView>
    {
        protected TView view;

        public ViewPresenterBase(TView view)
        {
            this.view = view;
        }

        public abstract void InitView();
    }
}
