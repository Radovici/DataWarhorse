using Core.Enums;
using Core.Interfaces.DataModels;

namespace Services.Risk
{
    public class RiskParameters : IRiskParameters
    {
        public RiskParameters(ISecurity security, DateOnly date, int range, double decay, double confidence, string type, RiskParameterPeriodType period)
        {
            Security = security;
            Date = date;
            Range = range;
            Decay = decay;
            Confidence = confidence;
            Type = type;
            Period = period;
        }

        public ISecurity Security { get; }
        public DateOnly Date { get; }
        public int Range { get; }
        public double Decay { get; }
        public double Confidence { get; }
        public string Type { get; }
        public RiskParameterPeriodType Period { get; }

        DateOnly IRiskParameters.Date => throw new NotImplementedException();

        public override string ToString()
        {
            return $"{Security},{Date.ToShortDateString()},{Range},{Decay},{Confidence},{Type},{Period}";
        }
    }
}
