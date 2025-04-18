using DataModels.EntityFramework.SecurityMaster.Contexts;
using DataModels.Interfaces;
using Services.MarketData;

namespace Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly SecurityMasterContext _securityMaster;
        private readonly IMarketDataService _marketDataService;

        public SecurityService(SecurityMasterContext securityMaster, IMarketDataService marketDataService)
        {
            _securityMaster = securityMaster;
            _marketDataService = marketDataService;

            RiskFreeSecurity = _securityMaster.Securities.FirstOrDefault(s => s.Symbol == "RF")
                ?? throw new InvalidOperationException("RF Security not found.");
            Spx = _securityMaster.Securities.FirstOrDefault(s => s.Symbol == "SPX")
                ?? throw new InvalidOperationException("SPX Security not found.");
        }

        public ISecurity RiskFreeSecurity { get; }

        public ISecurity Spx { get; }

        public ISecurity? GetSecurity(string symbol)
        {
            return _securityMaster.Securities.FirstOrDefault(s => s.Symbol == symbol);
        }

        public ISecurity? GetSecurity(int securityId)
        {
            return _securityMaster.Securities.SingleOrDefault(s => s.Id == securityId); // TODO: use dictionary
        }

        public double GetMarketValue(ISecurity security, DateTime date, double quantity)
        {
            var price = _marketDataService.GetPrice(security, date);
            if (price == null)
                throw new InvalidOperationException($"Price not found for {security.Symbol} on {date:yyyy-MM-dd}");

            return price.Value * quantity;
        }
    }
}
