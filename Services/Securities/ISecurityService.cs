using DataModels.Interfaces;

namespace Services.Securities
{
    public interface ISecurityService
    {
        ISecurity RiskFreeSecurity { get; }
        ISecurity Spx { get; }
        ISecurity? GetSecurity(string symbol);
    }
}
