using ExchangeOffice.App;

namespace ExchangeOffice
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var authForm = new AuthForm();
            System.Windows.Forms.Application.Run(authForm);

            if (authForm.UserSuccessfullyAuthenticated)
            {
                Application.Run(new MainForm());
            }
        }
    }
}