using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface ISecurityService
    {
        ISecurity RiskFreeSecurity { get; } // NOTE: where!? Needs to be regionized.
        ISecurity Spx { get; }
        ISecurity? GetSecurity(string symbol);
        ISecurity? GetSecurity(int securityId);
        double GetMarketValue(ISecurity security, DateTime date, double quantity);
    }
}
