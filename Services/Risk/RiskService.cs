using DataModels.Interfaces;
using Services.Securities;
using System.Collections.Specialized;

namespace Services.Risk;

public class RiskService : IRiskService
{
    private readonly ISecurityService _securityService;

    public RiskService(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    public RiskParameters CreateRiskParameters(NameValueCollection queryString, RiskParameters.RiskParameterType riskParameterType = RiskParameters.RiskParameterType.Beta)
    {
        if (queryString == null)
        {
            queryString = new NameValueCollection();
        }

        string symbol = queryString["Index"] ?? queryString["Security"] ?? RiskDefaults.DefaultBetaIndex;
        ISecurity security = _securityService.GetSecurity(symbol) ?? _securityService.Spx;

        DateTime dt = DateTime.TryParse(queryString["Date"], out var parsedDate) ? parsedDate : RiskDefaults.DefaultDate();
        int range = GetRange(queryString["Range"], riskParameterType, dt);
        double decay = GetDecay(queryString["Decay"], riskParameterType);
        double confidence = GetConfidence(queryString["Confidence"], riskParameterType);
        string type = queryString["Type"] ?? RiskDefaults.DefaultValueAtRiskType;
        RiskParameters.RiskParameterPeriodType period = Enum.TryParse(queryString["Period"], out RiskParameters.RiskParameterPeriodType parsedPeriod)
            ? parsedPeriod
            : RiskParameters.RiskParameterPeriodType.Weekly;

        return new RiskParameters(security, dt, range, decay, confidence, type, period);
    }

    public double GetValueAtRisk(SortedDictionary<DateTime, double> returns, RiskParameters riskParameters)
    {
        double[] decayedReturns = DecayReturns(returns.Values.ToArray(), riskParameters.Decay);
        return riskParameters.Type switch
        {
            "Normal" => 0, // TODO: Implement Normal VaR calculation
            "Historical" => 0, // TODO: Implement Historical VaR calculation
            _ => 0
        };
    }

    public double GetVolatility(SortedDictionary<DateTime, double> returns, RiskParameters riskParameters)
    {
        double[] decayedReturns = DecayReturns(returns.Values.ToArray(), riskParameters.Decay);
        return 0; // TODO: Implement standard deviation calculation
    }

    private static int GetRange(string? value, RiskParameters.RiskParameterType type, DateTime dt)
    {
        if (int.TryParse(value, out int range))
        {
            return range;
        }

        return type switch
        {
            RiskParameters.RiskParameterType.Volatility => RiskDefaults.DefaultVolatilityRange,
            RiskParameters.RiskParameterType.ValueAtRisk => RiskDefaults.DefaultValueAtRiskRange,
            RiskParameters.RiskParameterType.Correlation => RiskDefaults.DefaultBetaRange,
            RiskParameters.RiskParameterType.Volume => RiskDefaults.DefaultVolumeRange,
            RiskParameters.RiskParameterType.Sharpe => RiskDefaults.DefaultSharpeRange,
            RiskParameters.RiskParameterType.Performance => (dt.Subtract(dt.AddYears(-1)).Days * 5 / 7),
            RiskParameters.RiskParameterType.Beta => RiskDefaults.DefaultBetaRange,
            _ => RiskDefaults.DefaultBetaRange,
        };
    }

    private static double GetDecay(string? value, RiskParameters.RiskParameterType type)
    {
        if (double.TryParse(value, out double decay))
        {
            return decay;
        }

        return type switch
        {
            RiskParameters.RiskParameterType.Beta or RiskParameters.RiskParameterType.Volatility or RiskParameters.RiskParameterType.Correlation => 1,
            _ => 1,
        };
    }

    private static double GetConfidence(string? value, RiskParameters.RiskParameterType type)
    {
        return double.TryParse(value, out double confidence) ? confidence : RiskDefaults.DefaultValueAtRiskConfidence;
    }

    private static double[] DecayReturns(double[] returns, double decay)
    {
        if (decay >= 1) return returns;
        int length = returns.Length;
        double[] decayedReturns = new double[length];
        double d = 1.0;
        for (int index = 0; index < length; index++)
        {
            decayedReturns[length - 1 - index] = d * returns[length - 1 - index];
            d *= decay;
        }
        return decayedReturns;
    }
}