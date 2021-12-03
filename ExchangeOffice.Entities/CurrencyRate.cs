namespace ExchangeOffice.Entities
{
    public class CurrencyRate
    {
        public int ID { get; set; }

        public double Value { get; set; }

        public int CurrencyIDFrom { get; set; }

        virtual public Currency CurrencyFrom { get; set; }

        public int CurrencyIDTo { get; set; }

        virtual public Currency CurrencyTo { get; set; }

        public DateTime DateTime { get; set; }

        virtual public ICollection<OperationHistory> OperationHistories { get; set; }
    }
}
