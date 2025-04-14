using DataModels.PositionData;
using Services.Position;

namespace Tester
{
    public class TradeTest(ITradeService tradeService)
    {
        public async Task<IEnumerable<Trade>> GetTradesAsync()
        {
            var trades = await tradeService.GetTradesAsync();
            Console.WriteLine($"Number of trades = {trades.Count()}.");
            return trades;
        }
    }
}
