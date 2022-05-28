using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TradeBot_demo.Repository
{
    public class CurrencyPriceRepository
    {
        private readonly IDbConnection _db;

        public CurrencyPriceRepository()
        {
            _db = new SqlConnection("server=(localdb)\\ProjectModels;Initial Catalog=TradeBot_demo;Integrated Security=True");
        }
        public static decimal LTCETH { get; set; } = 0;
        public async Task AddCurrencyPrice(string date, decimal BTCUSDT, decimal ETHUSDT, decimal ETHBTC,
            decimal BNBBTC, decimal BNBUSDT, decimal BNBETH,
            decimal LTCBTC, decimal LTCUSDT, decimal LTCBNB,
            decimal LTCETH)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BTCUSDT", BTCUSDT);
            parameters.Add("ETHUSDT", ETHUSDT);
            parameters.Add("ETHBTC", ETHBTC);
            parameters.Add("BNBBTC", BNBBTC);
            parameters.Add("BNBUSDT", BNBUSDT);
            parameters.Add("BNBETH", BNBETH);
            parameters.Add("LTCBTC", LTCBTC);
            parameters.Add("LTCUSDT", LTCUSDT);
            parameters.Add("LTCBNB", LTCBNB);
            parameters.Add("LTCETH", LTCETH);

            parameters.Add("date", date);

            await _db.ExecuteAsync("AddCurrencyPrice", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
