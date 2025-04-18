namespace Core.Interfaces.Services
{
    public interface IMarketDataService
    {
        double? GetPrice(ISecurity security, DateTime date);
    }

}
