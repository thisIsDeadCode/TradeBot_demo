using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy_USDT_ETH_BNB : Strategy, IStrategy
    {
        public TriangularStrategy_USDT_ETH_BNB()
        {
            StartBalanceCurrency1 = 30000;
            BalanceCurrency1 = 30000;
        }

        public string Name { get; private set; } = "Triangular strategy USDT_ETH_BNB";
        public string Date { get; private set; }

        public string NameCurrency1 => "USDT";

        public string NameCurrency2 => "ETH";

        public string NameCurrency3 => "BNB";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.ETHUSDT) / CurrencyService.BNBETH) * CurrencyService.BNBUSDT;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
