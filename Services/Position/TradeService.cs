using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services.Position
{
    public class TradeService(PositionDataContext positionDataContext) : ITradeService
    {
        public async Task<IEnumerable<ITrade>> GetTradesAsync() // TODO: should be ITrade, need to abstract this stuff to make it usable for others
        {
            return await positionDataContext.Trades.Select(lmb => new UnifiedDataModels.Models.PositionData.Trade).ToListAsync<ITrade>();
        }
    }
}
