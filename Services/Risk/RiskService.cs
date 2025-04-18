using Core.Defaults;
using Core.Enums;
using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using System.Collections.Specialized;

namespace Services.Risk;

public class RiskService : IRiskService
{
    private readonly ISecurityService _securityService;

    public RiskService(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    public RiskParameters CreateRiskParameters(NameValueCollection queryString, RiskParameterType riskParameterType = RiskParameterType.Beta)
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
        RiskParameterPeriodType period = Enum.TryParse(queryString["Period"], out RiskParameterPeriodType parsedPeriod)
            ? parsedPeriod
            : RiskParameterPeriodType.Weekly;

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

    private static int GetRange(string? value, RiskParameterType type, DateTime dt)
    {
        if (int.TryParse(value, out int range))
        {
            return range;
        }

        return type switch
        {
            RiskParameterType.Volatility => RiskDefaults.DefaultVolatilityRange,
            RiskParameterType.ValueAtRisk => RiskDefaults.DefaultValueAtRiskRange,
            RiskParameterType.Correlation => RiskDefaults.DefaultBetaRange,
            RiskParameterType.Volume => RiskDefaults.DefaultVolumeRange,
            RiskParameterType.Sharpe => RiskDefaults.DefaultSharpeRange,
            RiskParameterType.Performance => (dt.Subtract(dt.AddYears(-1)).Days * 5 / 7),
            RiskParameterType.Beta => RiskDefaults.DefaultBetaRange,
            _ => RiskDefaults.DefaultBetaRange,
        };
    }

    private static double GetDecay(string? value, RiskParameterType type)
    {
        if (double.TryParse(value, out double decay))
        {
            return decay;
        }

        return type switch
        {
            RiskParameterType.Beta or RiskParameterType.Volatility or RiskParameterType.Correlation => 1,
            _ => 1,
        };
    }

    private static double GetConfidence(string? value, RiskParameterType type)
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

    IRiskParameters IRiskService.CreateRiskParameters(NameValueCollection queryString, RiskParameterType riskParameterType)
    {
        throw new NotImplementedException();
    }

    public double GetValueAtRisk(SortedDictionary<DateTime, double> returns, IRiskParameters riskParameters)
    {
        throw new NotImplementedException();
    }

    public double GetVolatility(SortedDictionary<DateTime, double> returns, IRiskParameters riskParameters)
    {
        throw new NotImplementedException();
    }
}