namespace TradeBot_demo.Strategies
{
    public interface IStrategy
    {
        public string Name { get;}

        public string NameCurrency1 { get; }
        public string NameCurrency2 { get; }
        public string NameCurrency3 { get; }

        public decimal StartBalanceCurrency1 { get; }
        public decimal StartBalanceCurrency2 { get; }
        public decimal StartBalanceCurrency3 { get; }

        public decimal BalanceCurrency1 { get; }
        public decimal BalanceCurrency2 { get; }
        public decimal BalanceCurrency3 { get; }

        public decimal ProfitCurrency1 { get; }
        public decimal ProfitCurrency2 { get; }
        public decimal ProfitCurrency3 { get; }

        public decimal PercentProfitCurrency1 { get; }
        public decimal PercentProfitCurrency2 { get; }
        public decimal PercentProfitCurrency3 { get; }

        public string Date { get; }

        public Task Execute(string date);
    }
}
