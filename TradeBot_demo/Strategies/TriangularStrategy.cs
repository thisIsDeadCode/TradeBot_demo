using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy : Strategy, IStrategy
    {
        public string Name { get; private set; } = "Triangule strategy";
        public string Date { get; private set; }

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceUSDT;

            BalanceUSDT = ((BalanceUSDT / CurrencyService.BTCUSDT) / CurrencyService.ETHBTC) * CurrencyService.ETHUSDT;

            ProfitUSDT = (BalanceUSDT - tempBalance);
            PercentProfitUSDT = ProfitUSDT / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
