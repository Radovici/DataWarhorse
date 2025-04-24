using Core.Interfaces.DataModels;
using Core.Interfaces.Services;

namespace Tester
{
    public class TradeTest(ITradeService tradeService)
    {
        public IEnumerable<ITrade> GetTrades()
        {
            var queryableTrades = tradeService.QueryableTrades.Take(10);
            var trades = tradeService.GetUnifiedTrades(queryableTrades);
            Console.WriteLine($"Number of trades = {trades.Count()}.");
            return trades;
        }
    }
}
