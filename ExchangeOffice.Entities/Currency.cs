namespace ExchangeOffice.Entities
{
    public class Currency
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        virtual public СurrencyLimit СurrencyLimit { get; set; }

        virtual public ICollection<CurrencyRate> CurrencyRateFrom { get; set; }

        virtual public ICollection<CurrencyRate> CurrencyRateTo { get; set; }
    }
}
