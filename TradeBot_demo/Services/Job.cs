using Quartz;
using TradeBot_demo.Repository;
using TradeBot_demo.Strategies;

namespace TradeBot_demo.Services
{
    public class Job : IJob
    {
        private readonly List<IStrategy> strategies;
        private readonly StrategyRepository strategyRepository;
        private readonly CurrencyPriceRepository currencyPriceRepository;

        public Job()
        {
            strategyRepository = new StrategyRepository();
            currencyPriceRepository = new CurrencyPriceRepository();

            strategies = new List<IStrategy>()
            {
                new TriangularStrategy_BNB_LTC_BTC(),
                new TriangularStrategy_BTC_ETH_USDT(),
                new TriangularStrategy_ETH_BNB_BTC(),
                new TriangularStrategy_ETH_BNB_LTC(),// мало торгов
                new TriangularStrategy_ETH_USDT_BTC(),
                new TriangularStrategy_USDT_BNB_BTC(),
                new TriangularStrategy_USDT_BNB_LTC(),
                new TriangularStrategy_USDT_BTC_ETH(),
                new TriangularStrategy_USDT_ETH_BNB(),
                new TriangularStrategy_USDT_ETH_BTC(),
                new TriangularStrategy_USDT_ETH_LTC(),// мало торгов
                new TriangularStrategy_USDT_LTC_BTC(),
            };
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var now = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine(now);
            CurrencyService.SendMessageToConsole();

            await currencyPriceRepository.AddCurrencyPrice(
                now,
                CurrencyService.BTCUSDT,
                CurrencyService.ETHUSDT,
                CurrencyService.ETHBTC,
                CurrencyService.BNBBTC,
                CurrencyService.BNBUSDT,
                CurrencyService.BNBETH,
                CurrencyService.LTCBTC,
                CurrencyService.LTCUSDT,
                CurrencyService.LTCBNB,
                CurrencyService.LTCETH
                );

            if (CurrencyService.BTCUSDT != 0 && CurrencyService.ETHBTC != 0 && CurrencyService.ETHBTC != 0 &&
                CurrencyService.BNBBTC != 0 && CurrencyService.BNBUSDT != 0 && CurrencyService.BNBETH != 0 &&
                CurrencyService.LTCBTC != 0 && CurrencyService.LTCUSDT != 0 && CurrencyService.LTCBNB != 0 &&
                CurrencyService.LTCETH != 0)
            {
                List<Task> tasks = new List<Task>();

                foreach (var strategy in strategies)
                {
                    tasks.Add(Task.Factory.StartNew(() => strategy.Execute(now)));
                }

                await Task.WhenAll(tasks);

                foreach (var strategy in strategies)
                {
                    await strategyRepository.AddStrategyData(strategy);
                }
            }
        }
    }
}
