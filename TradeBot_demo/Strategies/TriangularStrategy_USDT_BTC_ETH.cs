using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy_USDT_BTC_ETH : Strategy, IStrategy
    {
        public TriangularStrategy_USDT_BTC_ETH()
        {
            StartBalanceCurrency1 = 30000;
            BalanceCurrency1 = 30000;
        }

        public string Name { get; private set; } = "Triangular strategy USDT-BTC-ETH";
        public string Date { get; private set; }

        public string NameCurrency1 => "USDT";

        public string NameCurrency2 => "BTC";

        public string NameCurrency3 => "ETH";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.BTCUSDT) / CurrencyService.ETHBTC) * CurrencyService.ETHUSDT;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
