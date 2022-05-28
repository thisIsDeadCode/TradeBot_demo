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

            parameters.Add("nameCurrency1", strategy.NameCurrency1);
            parameters.Add("nameCurrency2", strategy.NameCurrency2);
            parameters.Add("nameCurrency3", strategy.NameCurrency3);

            parameters.Add("startBalanceCurrency1", strategy.StartBalanceCurrency1);
            parameters.Add("startBalanceCurrency2", strategy.StartBalanceCurrency2);
            parameters.Add("startBalanceCurrency3", strategy.StartBalanceCurrency3);

            parameters.Add("balanceCurrency1", strategy.BalanceCurrency1);
            parameters.Add("balanceCurrency2", strategy.BalanceCurrency2);
            parameters.Add("balanceCurrency3", strategy.BalanceCurrency3);

            parameters.Add("profitCurrency1", strategy.ProfitCurrency1);
            parameters.Add("profitCurrency2", strategy.ProfitCurrency2);
            parameters.Add("profitCurrency3", strategy.ProfitCurrency3);

            parameters.Add("percentProfitCurrency1", strategy.PercentProfitCurrency1);
            parameters.Add("percentProfitCurrency2", strategy.PercentProfitCurrency2);
            parameters.Add("percentProfitCurrency3", strategy.PercentProfitCurrency3);
            parameters.Add("date", strategy.Date);

            var t = await _db.ExecuteAsync("AddStrategyData", parameters, commandType: CommandType.StoredProcedure);
            //Console.WriteLine(t);
        }
    }
}
