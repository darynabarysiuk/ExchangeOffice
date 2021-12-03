namespace ExchangeOffice.Entities
{
    public class OperationHistory
    {
        public int ID { get; set; }

        public double Value { get; set; }

        public DateTime DateTime { get; set; }

        public int CurrencyRateID { get; set; }

        virtual public CurrencyRate CurrencyRate { get; set; }
    }
}
