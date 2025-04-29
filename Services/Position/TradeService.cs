using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataModels.EntityFramework.PositionInformation.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Position
{
    public class TradeService(PositionDataContext positionDataContext, ISecurityService securityService) : ITradeService
    {
        public IQueryable<ITrade> GetTrades()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ITradeData> QueryableTrades
        {
            get
            {
                return positionDataContext.Trades
                    .Include(lmb => lmb.Fund);
            }
        } // TODO: should be ITrade, need to abstract this stuff to make it usable for others

        public IEnumerable<ITrade> GetUnifiedTrades(IQueryable<ITradeData> queryableTrades)
        {
            return queryableTrades.Select(lmb => new UnifiedDataModels.Models.PositionData.Trade(lmb, securityService));
        }
    }
}
