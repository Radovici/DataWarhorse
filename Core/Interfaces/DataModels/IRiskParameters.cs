using Core.Enums;

namespace Core.Interfaces.DataModels
{
    public interface IRiskParameters
    {
        ISecurity Security { get; }
        DateTime Date { get; }
        int Range { get; }
        double Decay { get; }
        double Confidence { get; }
        string Type { get; }
        RiskParameterPeriodType Period { get; }
    }
}
