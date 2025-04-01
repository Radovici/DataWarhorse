using DataModels.EntityFramework.SecurityMaster.Contexts;
using DataModels.Interfaces;

namespace Services.Securities
{
    public class SecurityService : ISecurityService
    {
        private readonly SecurityMasterContext _securityMaster;

        public SecurityService(SecurityMasterContext securityMaster)
        {
            _securityMaster = securityMaster;
            // Load values during initialization
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
    }
}
