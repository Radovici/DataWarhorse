using DataModels.Interfaces;

namespace Services.Position
{
    public interface ITradeService
    {
        Task<IEnumerable<ITrade>> GetTradesAsync();
    }
}
