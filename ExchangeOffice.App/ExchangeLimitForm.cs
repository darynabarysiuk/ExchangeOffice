using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Entities;
using ExchangeOffice.Presenters;
using ExchangeOffice.Presenters.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeOffice.App
{
    public partial class ExchangeLimitForm : BaseForm, IExchangeLimitView
    {
        private IEnumerable<СurrencyLimit> currencyList = new List<СurrencyLimit>();

        public IEnumerable<СurrencyLimit> CurrencyList
        {
            get => currencyList;
            set
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(value.Select(s => s.Сurrency.ShortName).ToArray());
                currencyList = value;
                comboBox1.SelectedIndex = 0;
                textBox1.Text = currencyList.First().Limit.ToString();
            }
        }

        private ExchangeLimitPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IExchangeLimitView> presenter;

        public ExchangeLimitForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<ExchangeLimitPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = currencyList
                .FirstOrDefault(e => e.Сurrency.ShortName == SelectedCurrencyShortName)
                ?.Limit
                .ToString();
        }

        public event EventHandler OkClicked
        {
            add { button1.Click += value; }
            remove { button1.Click -= value; }
        }

        public string SelectedCurrencyShortName => (string)comboBox1.SelectedItem;

        public string NewValueForCurrencyLimit => textBox1.Text;
    }
}
