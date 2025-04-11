using DataModels.Interfaces;

namespace Services.Security
{
    public interface ISecurityService
    {
        ISecurity RiskFreeSecurity { get; } // NOTE: where!? Needs to be regionized.
        ISecurity Spx { get; }
        ISecurity? GetSecurity(string symbol);
        double GetMarketValue(ISecurity security, DateTime date, double quantity);
    }
}
