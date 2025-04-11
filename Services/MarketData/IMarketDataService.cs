using DataModels.Interfaces;

namespace Services.MarketData
{
    public interface IMarketDataService
    {
        double? GetPrice(ISecurity security, DateTime date);
    }

}
