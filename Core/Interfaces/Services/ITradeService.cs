using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface ITradeService
    {
        Task<IEnumerable<ITrade>> GetTradesAsync();
    }
}
