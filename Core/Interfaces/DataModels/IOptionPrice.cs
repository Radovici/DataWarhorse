namespace Core.Interfaces.DataModels
{
    public interface IOptionPrice : IPrice
    {
        double ImpliedVolatility { get; }
        double Delta { get; }
        double Gamma { get; }
        double Theta { get; }
        double Vega { get; }
    }
}
