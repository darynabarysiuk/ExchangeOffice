using Aspose.Pdf;
using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Entities;
using ExchangeOffice.Presenters;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.App
{
    public partial class HandlingClientForm : BaseForm, IHandlingClientView
    {
        private HandlingClientPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IHandlingClientView> presenter;
        
        public event EventHandler OperateClick
        { 
            add { button1.Click += value; } 
            remove { button1.Click -= value; } 
        }

        public HandlingClientForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<HandlingClientPresenter.Factory>();
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
                if (value.Count() < 2)
                {
                    ShowError("Невозможно провести операцию");
                    return;
                }
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox1.Items.AddRange(value.Select(s => s.ShortName).ToArray());
                comboBox2.Items.AddRange(value.Select(s => s.ShortName).ToArray());
                currencyList = value;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCurrencyTo == null || SelectedCurrencyFrom == null)
            {
                return;
            }
            if (SelectedCurrencyTo == SelectedCurrencyFrom)
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

        public event EventHandler TextFromChanged
        {
            add { textBox1.TextChanged += value; }
            remove { textBox1.TextChanged -= value; }
        }

        public event EventHandler TextToChanged
        {
            add { textBox2.TextChanged += value; }
            remove { textBox2.TextChanged -= value; }
        }

        public string TextValueFrom
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string TextValueTo
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public void ShowDialogWithCheckQuestion(Document check)
        {
            DialogResult result = MessageBox.Show("Загружать чек?", "Чек", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Pdf file|*.pdf";
                saveFileDialog1.Title = "Save check";
                saveFileDialog1.FileName = "Check";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                    check.Save(fs);
                    fs.Close();
                }
            }
            Close();
        }
    }
}
