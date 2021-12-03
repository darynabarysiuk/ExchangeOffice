namespace ExchangeOffice.IServices
{
    public interface IDateTimeService
    {
        public DateTime GetCurrentDateTime { get; }

        public void SetNewCurrentDate(DateTime newCurrentDate);
    }
}
