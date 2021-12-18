using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Entities;
using ExchangeOffice.Models;
using ExchangeOffice.Presenters;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.App
{

    public partial class OperationHistoryForm : BaseForm, IOperationHistoryView
    {
        private OperationHistoryPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IOperationHistoryView> presenter;

        public IEnumerable<OperationHistoryModelView> operations { get; set; }

        public OperationHistoryForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<OperationHistoryPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();

            var source = new BindingSource();
            source.DataSource = operations;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = source;
        }
    }
}
