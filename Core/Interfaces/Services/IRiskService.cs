﻿using Core.Enums;
using Core.Interfaces.DataModels;
using System.Collections.Specialized;

namespace Core.Interfaces.Services
{
    public interface IRiskService
    {
        IRiskParameters CreateRiskParameters(NameValueCollection queryString, RiskParameterType riskParameterType = RiskParameterType.Beta);
        double GetValueAtRisk(SortedDictionary<DateOnly, double> returns, IRiskParameters riskParameters);
        double GetVolatility(SortedDictionary<DateOnly, double> returns, IRiskParameters riskParameters);
    }
}
