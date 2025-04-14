using DataModels.PositionData;

namespace Services.Position
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> GetTradesAsync();
    }
}
