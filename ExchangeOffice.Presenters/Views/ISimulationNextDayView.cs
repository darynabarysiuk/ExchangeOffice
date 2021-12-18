using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters.Views
{
    public interface ISimulationNextDayView : IBaseView
    {
        event EventHandler OkClicked;

        DateTime CurrentDate { get; set; }
    }
}
