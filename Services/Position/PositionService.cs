using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;


namespace Services.Position
{
    public class PositionService(PositionDataContext positionDataContext)
    {
        public async Task<IEnumerable<Trade>> GetTradesAsync()
        {
            return await positionDataContext.Trades.ToListAsync();
        }
    }
}
