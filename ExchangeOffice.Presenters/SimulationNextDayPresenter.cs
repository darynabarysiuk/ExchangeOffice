using ExchangeOffice.IServices;
using ExchangeOffice.Presenters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Presenters
{
    public class SimulationNextDayPresenter : ViewPresenterBase<ISimulationNextDayView>
    {
        private readonly IDateTimeService dateTimeService;

        public delegate SimulationNextDayPresenter Factory(ISimulationNextDayView view);


        public SimulationNextDayPresenter(ISimulationNextDayView view, IDateTimeService dateTimeService)
            : base(view)
        {
            this.dateTimeService = dateTimeService;
        }

        public override void InitView()
        {
            view.OkClicked += View_OkClicked;
            view.CurrentDate = dateTimeService.GetCurrentDateTime;
        }

        private void View_OkClicked(object? sender, EventArgs e)
        {
            if(view.CurrentDate.Date < dateTimeService.GetCurrentDateTime.Date)
            {
                view.ShowError("Неверно выбранна дата");
            }
            else
            {
                dateTimeService.SetNewCurrentDate(view.CurrentDate);
                view.Close();
            }
        }
    }
}
