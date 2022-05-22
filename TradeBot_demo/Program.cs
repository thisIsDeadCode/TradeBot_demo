using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;

using System;
using System.Threading.Tasks;
using TradeBot_demo.Services;

class Program
{
    static void Main(string[] args)
    {
        BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions()
        {
            ApiCredentials = new ApiCredentials(
                "3WVntMaeHayWsLCrXh4pnzvM3xnqjiO89hSrquoJfP0MTfI4bDHRnKDfNXhPKAS2",
                "tIcwcg1AI3If1NQkyMGltYQtAALKhh1mieEzgCwPw2UnurP5821tdCWtQw2Wmgsc")
        });


        //_ = Task.Run(async () =>
        //{
        //    while (true)
        //    {
        //        Console.Clear();

        //        await Task.Delay(10000);
        //    }
        //});

        CurrencyService currencyService = new CurrencyService();
        _ = Task.Run(() => currencyService.GetPriceCurrency());

        Scheduler.Start();

        Console.ReadLine();
    }
}
