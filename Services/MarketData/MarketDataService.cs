using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using DataModels.EntityFramework.MarketData.Contexts;

namespace Services.MarketData
{
    public class MarketDataService : IMarketDataService
    {
        private readonly MarketDataContext _context;

        public MarketDataService(MarketDataContext context)
        {
            _context = context;
        }

        public double? GetPrice(ISecurity security, DateOnly date)
        {
            // Add fallback logic, pricing model overrides, etc. as needed
            var prices = this.GetPrices(security);
            var price = prices?.SingleOrDefault(lmb => lmb.Date == date); // TODO: assumes one price per security per day (or DateOnly), not intraday whose tick data would use DateTime rather than DateOnly
            return price?.EndPrice;
        }

        public IQueryable<IPrice> GetPrices(ISecurity security)
        {
            var prices = _context.EquityPrices
                .Where(p => p.SecurityId == security.Id);
            return prices;
        }
    }

}
