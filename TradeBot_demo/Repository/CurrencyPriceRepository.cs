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

        public async Task AddCurrencyPrice(string date, decimal BTCUSDT, decimal ETHUSDT, decimal ETHBTC)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BTCUSDT", BTCUSDT);
            parameters.Add("ETHUSDT", ETHUSDT);
            parameters.Add("ETHBTC", ETHBTC);
            parameters.Add("date", date);

            await _db.ExecuteAsync("AddCurrencyPrice", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
