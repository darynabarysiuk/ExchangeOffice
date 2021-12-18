using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Presenters;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.App
{
    public partial class MainForm : BaseForm, IMainView
    {
        private MainPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IMainView> presenter;

        public MainForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<MainPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExchangeLimitForm exchangeLimitForm = new ExchangeLimitForm();
            exchangeLimitForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SimulationNextDayForm simulationNextDayForm = new SimulationNextDayForm();
            simulationNextDayForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OperationHistoryForm operationHistoryForm = new OperationHistoryForm();
            operationHistoryForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExchangeRatesForm exchangeRatesForm = new ExchangeRatesForm();
            exchangeRatesForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HandlingClientForm handlingClientForm = new HandlingClientForm();
            handlingClientForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
