using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataModels.EntityFramework.PositionInformation.Contexts;

namespace Services.Position
{
    public class TradeService(PositionDataContext positionDataContext, ISecurityService securityService) : ITradeService
    {
        public IQueryable<ITrade> GetTrades() // TODO: should be ITrade, need to abstract this stuff to make it usable for others
        {
            return positionDataContext.Trades
                .Select(lmb => new UnifiedDataModels.Models.PositionData.Trade(lmb, securityService));
        }
    }
}
