namespace ExchangeOffice.Entities
{
    public class СurrencyLimit
    {
        public int ID { get; set; }

        public double Limit { get; set; }

        public int CurrencyID { get; set; }

        virtual public Currency Сurrency { get; set; }
    }
}
