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
    public partial class ExchangeRatesForm : BaseForm, IExchangeRatesView
    {
        private ExchangeRatesPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IExchangeRatesView> presenter;

        public ExchangeRatesForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<ExchangeRatesPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();
        }
        private IEnumerable<Currency> currencyList = new List<Currency>();

        public IEnumerable<Currency> CurrencyList
        {
            get => currencyList;
            set
            {
                if(value.Count() < 2)
                {
                    ShowError("Невозможность задать курс");
                    return;
                }
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox1.Items.AddRange(value.Select(s => s.ShortName).ToArray());
                comboBox2.Items.AddRange(value.Select(s => s.ShortName).ToArray());
                currencyList = value;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
                setCurrencyRate?.Invoke(null, new EventArgs());
            }
        }

        private event EventHandler? setCurrencyRate = null;
        public event EventHandler SetCurrencyRate
        { 
            add { setCurrencyRate += value; }
            remove { setCurrencyRate -= value; }
        }

        public string SelectedCurrencyFrom => (string)comboBox1.SelectedItem;
        
        public string SelectedCurrencyTo => (string)comboBox2.SelectedItem;

        public string ValueForCurrencyRate
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectedCurrencyTo == null || SelectedCurrencyFrom == null)
            {
                return;
            }
            if(SelectedCurrencyTo == SelectedCurrencyFrom)
            {
                ShowError("Невозможно выбрать две одинаковые валюты");
                comboBox1.SelectedIndex = (comboBox2.SelectedIndex + 1) % comboBox1.Items.Count;
            }
            setCurrencyRate?.Invoke(null, new EventArgs());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCurrencyTo == null || SelectedCurrencyFrom == null)
            {
                return;
            }
            if (SelectedCurrencyTo == SelectedCurrencyFrom)
            {
                ShowError("Невозможно выбрать две одинаковые валюты");
                comboBox2.SelectedIndex = (comboBox1.SelectedIndex + 1) % comboBox2.Items.Count;
            }
            setCurrencyRate?.Invoke(null, new EventArgs());
        }

        public event EventHandler OkClick
        {
            add { button1.Click += value; }
            remove { button1.Click -= value; }
        }
    }
}
