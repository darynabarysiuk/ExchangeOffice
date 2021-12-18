using ExchangeOffice.Presenters.Views;
using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Presenters;

namespace ExchangeOffice.App
{
    public partial class SimulationNextDayForm : BaseForm, ISimulationNextDayView
    {
        public event EventHandler OkClicked
        {
            add { button1.Click += value; }
            remove { button1.Click -= value; }
        }

        public DateTime CurrentDate
        {
            get { return monthCalendar.SelectionRange.Start; } 
            set { monthCalendar.SetDate(value);  } 
        }

        private SimulationNextDayPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<ISimulationNextDayView> presenter;

        public SimulationNextDayForm()
        {
            InitializeComponent();
            monthCalendar.MaxSelectionCount = 1;

            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<SimulationNextDayPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();
            monthCalendar.SetDate(CurrentDate);
        }

        public void ShowError(string error)
        {
            MessageBox.Show("Ошибка! " + error, "Ошибка");
        }
    }
}
