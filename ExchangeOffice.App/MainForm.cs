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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
