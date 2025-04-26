using Core.Interfaces.DataModels;
using Core.Interfaces.Services;

namespace UnifiedDataModels.Models.SecurityMaster
{
    public class Security : ISecurity
    {
        private ISecurity _security;
        private IMarketDataService _marketDataService;

        public Security(ISecurity security, IMarketDataService marketDataService)
        {
            _security = security;
            _marketDataService = marketDataService;
        }

        public int Id => _security.Id;

        public ISecurity? UnderlyingSecurity => _security.UnderlyingSecurity;

        public ISecurityType SecurityType => _security.SecurityType;

        public string Symbol => _security.Symbol;

        public double Multiplier => _security.Multiplier;

        public ICurrency Currency => _security.Currency;

        public IExchange Exchange => _security.Exchange;

        public IEnumerable<ISecurityAttribute> SecurityAttributes => _security.SecurityAttributes;

        public string Name => _security.Name;

        public DateOnly MaxDate
        {
            get
            {
                return DateOnly.FromDateTime(DateTime.Today); //_marketDataService
            }
        }
    }
}
