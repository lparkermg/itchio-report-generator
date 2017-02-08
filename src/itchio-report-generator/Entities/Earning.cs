namespace Entities
{
    public class Earning
    {
        public string Currency { get; private set; }
        public string AmountFormatted { get; private set; }
        public double Amount { get; private set; }

        public Earning(string currency, string amountFormatted, double amount)
        {
            Currency = currency;
            AmountFormatted = amountFormatted;
            Amount = amount;
        }
    }
}