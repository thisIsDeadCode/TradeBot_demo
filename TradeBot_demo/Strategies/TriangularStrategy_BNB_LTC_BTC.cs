using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    public class TriangularStrategy_BNB_LTC_BTC : Strategy, IStrategy
    {
        public TriangularStrategy_BNB_LTC_BTC()
        {
            StartBalanceCurrency1 = 100;
            BalanceCurrency1 = 100;
        }

        public string Name { get; private set; } = "Triangular strategy BNB_LTC_BTC";
        public string Date { get; private set; }

        public string NameCurrency1 => "BNB";

        public string NameCurrency2 => "LTC";

        public string NameCurrency3 => "BTC";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance =  BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.LTCBNB) * CurrencyService.LTCBTC) / CurrencyService.BNBBTC;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
