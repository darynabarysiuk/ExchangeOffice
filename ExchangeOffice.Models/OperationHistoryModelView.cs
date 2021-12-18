namespace ExchangeOffice.Models
{
    public class OperationHistoryModelView
    {
        public double Value { get; set; }

        public DateTime DateTime { get; set; }

        public string ShortNameFrom { get; set; }

        public string ShortNameTo { get; set; }

        public double CurrencyValue { get; set; }
    }
}