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
                new SimpleStrategy(),
                new TriangularStrategy(),
            };
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var now = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine(now);

            List<Task> tasks = new List<Task>();
            List<Task> saveToDbTasks = new List<Task>();

            saveToDbTasks.Add(Task.Factory.StartNew(() => currencyPriceRepository.AddCurrencyPrice(
                now,
                CurrencyService.BTCUSDT,
                CurrencyService.ETHUSDT,
                CurrencyService.ETHBTC)));

            if (CurrencyService.BTCUSDT != 0 && CurrencyService.ETHBTC != 0 && CurrencyService.ETHBTC != 0)
            {
                foreach (var strategy in strategies)
                {
                    tasks.Add(Task.Factory.StartNew(() => strategy.Execute(now)));
                }

                await Task.WhenAll(tasks);


                foreach (var strategy in strategies)
                {
                    await strategyRepository.AddStrategyData(strategy);
                }
                await Task.WhenAll(saveToDbTasks);
            }
        }
    }
}
