using Binance.Net.Clients;

namespace TradeBot_demo.Services
{
    public class CurrencyService
    {
        public static decimal BTCUSDT { get; set; } = 0;
        public static decimal ETHUSDT { get; set; } = 0;
        public static decimal ETHBTC { get; set; } = 0;

        public async Task GetPriceCurrency()
        {
            List<Task> tasks = new List<Task>()
            {
                Task.Factory.StartNew(() => GetPriceCurrencyBinance()),
            };

            await Task.WhenAll(tasks);
        }

        private void GetPriceCurrencyBinance()
        {
            var socketClient = new BinanceSocketClient();

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("BTCUSDT", data =>
            {
                BTCUSDT = data.Data.Price;
                //Console.WriteLine($"BTCUSDT={BTCUSDT}   ETHUSDT={ETHUSDT}   ETHBTC={ETHBTC}");
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("ETHUSDT", data =>
            {
                ETHUSDT = data.Data.Price;
                //Console.WriteLine($"BTCUSDT={BTCUSDT}   ETHUSDT={ETHUSDT}   ETHBTC={ETHBTC}");
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("ETHBTC", data =>
            {
                ETHBTC = data.Data.Price;
                //Console.WriteLine($"BTCUSDT={BTCUSDT}   ETHUSDT={ETHUSDT}   ETHBTC={ETHBTC}");
            });
        }
    }
}
