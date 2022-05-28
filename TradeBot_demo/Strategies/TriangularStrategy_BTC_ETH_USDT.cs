using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    internal class TriangularStrategy_BTC_ETH_USDT : Strategy, IStrategy
    {
        public TriangularStrategy_BTC_ETH_USDT()
        {
            StartBalanceCurrency1 = 1;
            BalanceCurrency1 = 1;
        }

        public string Name => "Triangular strategy BTC-ETH-USDT";

        public string Date { get; private set; }


        public string NameCurrency1 => "BTC";

        public string NameCurrency2 => "ETH";

        public string NameCurrency3 => "USDT";

       

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance = BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 / CurrencyService.ETHBTC) * CurrencyService.ETHUSDT) / CurrencyService.BTCUSDT;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
