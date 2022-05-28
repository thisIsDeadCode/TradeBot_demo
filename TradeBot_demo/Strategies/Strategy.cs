namespace TradeBot_demo.Strategies
{
    public abstract class Strategy
    {
        public decimal StartBalanceCurrency1 { get; protected set; }
        public decimal StartBalanceCurrency2 { get; protected set; }
        public decimal StartBalanceCurrency3 { get; protected set; }

        public decimal BalanceCurrency1 { get; protected set; }
        public decimal BalanceCurrency2 { get; protected set; } 
        public decimal BalanceCurrency3 { get; protected set; } 

        public decimal ProfitCurrency1 { get; protected set; }
        public decimal ProfitCurrency2 { get; protected set; }
        public decimal ProfitCurrency3 { get; protected set; }

        public decimal PercentProfitCurrency1 { get; protected set; }
        public decimal PercentProfitCurrency2 { get; protected set; }
        public decimal PercentProfitCurrency3 { get; protected set; }
    }
}
