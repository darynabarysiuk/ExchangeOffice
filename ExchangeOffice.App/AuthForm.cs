using Autofac;
using ExchangeOffice.App.Autofac;
using ExchangeOffice.Presenters;
using ExchangeOffice.Presenters.Views;

namespace ExchangeOffice.App
{
    public partial class AuthForm : Form, IAuthView
    {
        public string Login => textBox1.Text;

        public string Password => textBox2.Text;

        private AuthPresenter.Factory presenterFactory { get; set; }

        private ViewPresenterBase<IAuthView> presenter;

        public AuthForm()
        {
            InitializeComponent();
            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<AuthPresenter.Factory>();
                presenter = presenterFactory(this);
            }
            presenter.InitView();
        }

        public event EventHandler AuthClicked 
        { 
            add { AuthButton.Click += value; } 
            remove { AuthButton.Click -= value; } 
        }

        public void ToMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        public void ShowError(string error)
        {
            MessageBox.Show("Ошибка! " + error, "Ошибка");
        }
    }
}