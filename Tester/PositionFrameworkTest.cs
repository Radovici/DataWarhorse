﻿using Core.Interfaces.Services;
using PositionFramework;

namespace Tester
{
    public class PositionFrameworkTest(ITradeService tradeService, IMarketDataService marketDataService)
    {
        public double BuildPortfolioAndReturnCalculatedPnl()
        {
            var queryableTrades = tradeService.QueryableTrades.Take(10);
            var trades = tradeService.GetUnifiedTrades(queryableTrades);
            Console.WriteLine($"Number of trades = {trades.Count()}.");
            Portfolio portfolio = new Portfolio(trades, marketDataService);
            return portfolio.Pnl;
        }
    }
}
