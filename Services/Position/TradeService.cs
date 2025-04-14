using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;

namespace Services.Position
{
    public class TradeService(PositionDataContext positionDataContext) : ITradeService
    {
        public async Task<IEnumerable<Trade>> GetTradesAsync() // TODO: should be ITrade, need to abstract this stuff to make it usable for others
        {
            return await positionDataContext.Trades.ToListAsync();
        }
    }
}
