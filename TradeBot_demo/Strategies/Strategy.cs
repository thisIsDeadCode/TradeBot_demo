namespace TradeBot_demo.Strategies
{
    public abstract class Strategy
    {
        public decimal StartBalanceUSDT { get; protected set; } = 10000;
        public decimal StartBalanceBTC { get; protected set; }
        public decimal StartBalanceETH { get; protected set; }

        public decimal BalanceUSDT { get; protected set; } = 10000;
        public decimal BalanceBTC { get; protected set; } 
        public decimal BalanceETH { get; protected set; } 

        public decimal ProfitUSDT { get; protected set; }
        public decimal ProfitBTC { get; protected set; }
        public decimal ProfitETH { get; protected set; }

        public decimal PercentProfitUSDT { get; protected set; }
        public decimal PercentProfitBTC { get; protected set; }
        public decimal PercentProfitETH { get; protected set; }
    }
}
