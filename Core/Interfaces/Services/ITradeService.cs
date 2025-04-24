using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface ITradeService
    {
        IQueryable<IQueryableTrade> QueryableTrades { get; }

        IEnumerable<ITrade> GetUnifiedTrades(IQueryable<IQueryableTrade> queryableTrades);
    }
}
