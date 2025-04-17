using DataModels.Interfaces;
using Services.Position;

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
