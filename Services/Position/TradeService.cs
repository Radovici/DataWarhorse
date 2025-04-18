using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataModels.EntityFramework.PositionInformation.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Position
{
    public class TradeService(PositionDataContext positionDataContext, ISecurityService securityService) : ITradeService
    {
        public async Task<IEnumerable<ITrade>> GetTradesAsync() // TODO: should be ITrade, need to abstract this stuff to make it usable for others
        {
            return (await positionDataContext.Trades.ToListAsync())
                .Select(lmb => new UnifiedDataModels.Models.PositionData.Trade(lmb, securityService));
        }
    }
}
