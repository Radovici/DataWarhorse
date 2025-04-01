using System.Collections.Specialized;

namespace Services.Risk
{
    public interface IRiskService
    {
        RiskParameters CreateRiskParameters(NameValueCollection queryString, RiskParameters.RiskParameterType riskParameterType = RiskParameters.RiskParameterType.Beta);
        double GetValueAtRisk(SortedDictionary<DateTime, double> returns, RiskParameters riskParameters);
        double GetVolatility(SortedDictionary<DateTime, double> returns, RiskParameters riskParameters);
    }
}
