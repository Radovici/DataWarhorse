using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface ITradeService
    {
        IQueryable<ITradeData> QueryableTrades { get; }

        IEnumerable<ITrade> GetUnifiedTrades(IQueryable<ITradeData> queryableTrades);
    }
}
