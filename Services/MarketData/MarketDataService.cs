using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.Interfaces;

namespace Services.MarketData
{
    public class MarketDataService : IMarketDataService
    {
        private readonly MarketDataContext _context;

        public MarketDataService(MarketDataContext context)
        {
            _context = context;
        }

        public double? GetPrice(ISecurity security, DateTime date)
        {
            // Add fallback logic, pricing model overrides, etc. as needed
            var price = _context.EquityPrices
                .FirstOrDefault(p => p.SecurityId == security.Id && p.Date == date.Date);

            return price?.EndPrice;
        }
    }

}
