using ExchangeOffice.Common;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDateTime => Configuration.CurrentDate + DateTime.Now.TimeOfDay;

        public void SetNewCurrentDate(DateTime newCurrentDate)
        {
            Configuration.CurrentDate = newCurrentDate.Date;
        }
    }
}
