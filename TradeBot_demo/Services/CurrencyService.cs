using Binance.Net.Clients;

namespace TradeBot_demo.Services
{
    public class CurrencyService
    {
        public static decimal BTCUSDT { get; set; } = 0;
        public static decimal ETHUSDT { get; set; } = 0;
        public static decimal ETHBTC { get; set; } = 0;
        public static decimal BNBBTC { get; set; } = 0;
        public static decimal BNBUSDT { get; set; } = 0;
        public static decimal BNBETH { get; set; } = 0;
        public static decimal LTCBTC { get; set; } = 0;
        public static decimal LTCUSDT { get; set; } = 0;
        public static decimal LTCBNB { get; set; } = 0;
        public static decimal LTCETH { get; set; } = 0;


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
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("ETHUSDT", data =>
            {
                ETHUSDT = data.Data.Price;
                
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("ETHBTC", data =>
            {
                ETHBTC = data.Data.Price;
            });


            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("BNBBTC", data =>
            {
                BNBBTC = data.Data.Price;
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("BNBUSDT", data =>
            {
                BNBUSDT = data.Data.Price;
            });
            
            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("BNBETH", data =>
            {
                BNBETH = data.Data.Price;
            });
            
            
            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("LTCBTC", data =>
            {
                LTCBTC = data.Data.Price;
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("LTCUSDT", data =>
            {
                LTCUSDT = data.Data.Price;
            });
            
            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("LTCBNB", data =>
            {
                LTCBNB = data.Data.Price;
            });

            _ = socketClient.SpotStreams.SubscribeToTradeUpdatesAsync("LTCETH", data =>
            {
                LTCETH = data.Data.Price;
            });
        }

        public static void SendMessageToConsole()
        {
            Console.WriteLine($"BTCUSDT={BTCUSDT}   ETHUSDT={ETHUSDT}   ETHBTC={ETHBTC}     " +
                   $"BNBBTC={BNBBTC}   BNBUSDT={BNBUSDT}   ETHBTC={BNBETH}     " +
                   $"LTCBTC={LTCBTC}   LTCUSDT={LTCUSDT}   LTCBNB={LTCBNB}     LTCETH={LTCETH}");
        }
    }
}
