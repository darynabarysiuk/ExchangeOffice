using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeOffice.Application
{
    public partial class HandlingClientForm : Form
    {
        public HandlingClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Операция невозможна! Привышено ограничение", "Ошибка");
            DialogResult result = MessageBox.Show("Загружать чек?", "Чек", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {

            }
        }
    }
}
