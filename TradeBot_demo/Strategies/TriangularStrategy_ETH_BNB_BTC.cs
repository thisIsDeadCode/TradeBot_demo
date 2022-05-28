using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy_ETH_BNB_BTC : Strategy, IStrategy
    {
        public TriangularStrategy_ETH_BNB_BTC()
        {
            StartBalanceCurrency1 = 15;
            BalanceCurrency1 = 15;
        }

        public string Name { get; private set; } = "Triangular strategy ETH_BNB_BTC";
        public string Date { get; private set; }

        public string NameCurrency1 => "ETH";

        public string NameCurrency2 => "BNB";

        public string NameCurrency3 => "BTC";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.BNBETH) * CurrencyService.BNBBTC) / CurrencyService.ETHBTC;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
