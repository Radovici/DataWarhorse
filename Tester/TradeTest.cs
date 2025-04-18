using Core.Interfaces.DataModels;
using Core.Interfaces.Services;

namespace Tester
{
    public class TradeTest(ITradeService tradeService)
    {
        public async Task<IEnumerable<ITrade>> GetTradesAsync()
        {
            var trades = await tradeService.GetTradesAsync();
            Console.WriteLine($"Number of trades = {trades.Count()}.");
            return trades;
        }
    }
}
