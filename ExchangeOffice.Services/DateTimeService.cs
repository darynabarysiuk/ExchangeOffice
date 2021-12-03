using ExchangeOffice.Common;

namespace ExchangeOffice.Services
{
    public class DateTimeService
    {
        public DateTime GetCurrentDateTime => Configuration.CurrentDate + DateTime.Now.TimeOfDay;

        public void SetNewCurrentDate(DateTime newCurrentDate)
        {
            Configuration.CurrentDate = newCurrentDate.Date;
        }
    }
}
