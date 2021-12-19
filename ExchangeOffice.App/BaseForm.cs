using ExchangeOffice.Presenters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.App
{
    public class BaseForm : Form, IBaseView
    {
        public void ShowError(string error)
        {
            MessageBox.Show("Ошибка! " + error, "Ошибка");
        }

        protected void HandleDoudleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string startText = ((TextBox)sender).Text;
            try
            {
                if (e.KeyChar == '\b')
                {
                    startText = startText.Remove(startText.Length - 1);
                }
                else
                {
                    startText = startText + e.KeyChar;
                }
                if (startText == "")
                {
                    return;
                }
                double value = Convert.ToDouble(startText);
                if (value < 0)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex) { e.Handled = true; }
        }
    }
}
