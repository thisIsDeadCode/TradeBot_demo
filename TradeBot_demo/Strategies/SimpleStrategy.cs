using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBot_demo.Strategies
{
    internal class SimpleStrategy : Strategy, IStrategy
    {
        public string Name => "Simple strategy";

        public string Date { get; private set; }

        public Task Execute(string date)
        {
            Date = date;
            return Task.CompletedTask;
        }
    }
}
