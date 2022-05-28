using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBot_demo.Services;

namespace TradeBot_demo.Strategies
{
    internal class TriangularStrategy_ETH_USDT_BTC : Strategy, IStrategy
    {
        public TriangularStrategy_ETH_USDT_BTC()
        {
            StartBalanceCurrency1 = 15;
            BalanceCurrency1 = 15;
        }

        public string Name => "Triangular strategy ETH-USDT-BTC";

        public string Date { get; private set; }


        public string NameCurrency1 => "ETH";

        public string NameCurrency2 => "USDT";

        public string NameCurrency3 => "BTC";

        public Task Execute(string date)
        {
            Date = date;
            var tempBalance = BalanceCurrency1;

            BalanceCurrency1 = ((BalanceCurrency1 * CurrencyService.ETHUSDT) / CurrencyService.BTCUSDT) / CurrencyService.ETHBTC;

            ProfitCurrency1 = (BalanceCurrency1 - tempBalance);
            PercentProfitCurrency1 = ProfitCurrency1 / tempBalance * 100;

            return Task.CompletedTask;
        }
    }
}
