using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy_USDT_ETH_LTC : Strategy, IStrategy
    {
        public TriangularStrategy_USDT_ETH_LTC()
        {
            StartBalanceCurrency1 = 30000;
            BalanceCurrency1 = 30000;
        }

        public string Name { get; private set; } = "Triangular strategy USDT_ETH_LTC";
        public string Date { get; private set; }

        public string NameCurrency1 => "USDT";

        public string NameCurrency2 => "ETH";

        public string NameCurrency3 => "LTC";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceCurrency1;

            //BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.ETHUSDT) / CurrencyService.LTCETH) * CurrencyService.LTCUSDT;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
