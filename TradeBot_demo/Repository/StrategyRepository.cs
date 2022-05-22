using Dapper;
using System.Data;
using System.Data.SqlClient;
using TradeBot_demo.Strategies;

namespace TradeBot_demo.Repository
{
    public class StrategyRepository
    {
        private readonly IDbConnection _db;

        public StrategyRepository()
        {
            _db = new SqlConnection("server=(localdb)\\ProjectModels;Initial Catalog=TradeBot_demo;Integrated Security=True");
        }

        public async Task AddStrategyData(IStrategy strategy)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", strategy.Name);
            parameters.Add("startBalanceUSDT", strategy.StartBalanceUSDT);
            parameters.Add("startBalanceBTC", strategy.StartBalanceBTC);
            parameters.Add("startBalanceETH", strategy.StartBalanceETH);
            parameters.Add("balanceUSDT", strategy.BalanceUSDT);
            parameters.Add("balanceBTC", strategy.BalanceBTC);
            parameters.Add("balanceETH", strategy.BalanceETH);
            parameters.Add("profitUSDT", strategy.ProfitUSDT);
            parameters.Add("profitBTC", strategy.ProfitBTC);
            parameters.Add("profitETH", strategy.ProfitETH);
            parameters.Add("percentProfitUSDT", strategy.PercentProfitUSDT);
            parameters.Add("percentProfitBTC", strategy.PercentProfitBTC);
            parameters.Add("percentProfitETH", strategy.PercentProfitETH);
            parameters.Add("date", strategy.Date);

            var t = await _db.ExecuteAsync("AddStrategyData", parameters, commandType: CommandType.StoredProcedure);
            Console.WriteLine(t);
        }
    }
}
