namespace TradeBot_demo.Strategies
{
    public interface IStrategy
    {
        public string Name { get;}

        public decimal StartBalanceUSDT { get; }
        public decimal StartBalanceBTC { get; }
        public decimal StartBalanceETH { get; }

        public decimal BalanceUSDT { get; }
        public decimal BalanceBTC { get; }
        public decimal BalanceETH { get; }

        public decimal ProfitUSDT { get; }
        public decimal ProfitBTC { get; }
        public decimal ProfitETH { get; }

        public decimal PercentProfitUSDT { get; }
        public decimal PercentProfitBTC { get; }
        public decimal PercentProfitETH { get; }

        public string Date { get; }

        public Task Execute(string date);
    }
}
