using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface ITradeService
    {
        IQueryable<ITrade> GetTrades();
    }
}
