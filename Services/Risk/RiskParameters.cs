using DataModels.Interfaces;

namespace Services.Risk
{
    public class RiskParameters
    {
        public enum RiskParameterType
        {
            Beta = 0, Volatility = 1, ValueAtRisk = 2, Correlation = 3, Volume = 4, Sharpe = 5, Performance = 6
        }

        public enum RiskParameterPeriodType
        {
            Daily = 0, Weekly = 1
        }

        public RiskParameters(ISecurity security, DateTime date, int range, double decay, double confidence, string type, RiskParameterPeriodType period)
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
        public DateTime Date { get; }
        public int Range { get; }
        public double Decay { get; }
        public double Confidence { get; }
        public string Type { get; }
        public RiskParameterPeriodType Period { get; }

        public override string ToString()
        {
            return $"{Security},{Date.ToShortDateString()},{Range},{Decay},{Confidence},{Type},{Period}";
        }
    }
}
