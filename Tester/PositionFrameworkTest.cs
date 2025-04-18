using Core.Interfaces.Services;
using PositionFramework;

namespace Tester
{
    public class PositionFrameworkTest(ITradeService tradeService)
    {
        public async Task<double> BuildPortfolioAndReturnCalculatedPnl()
        {
            var trades = await tradeService.GetTradesAsync();
            Console.WriteLine($"Number of trades = {trades.Count()}.");
            Portfolio portfolio = new Portfolio(trades);
            return portfolio.Pnl;
        }
    }
}
