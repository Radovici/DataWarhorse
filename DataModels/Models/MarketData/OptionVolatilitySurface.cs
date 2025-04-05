namespace DataModels.MarketData;

public partial class OptionVolatilitySurface
{
    public int SecurityId { get; private set; }

    public DateOnly Date { get; private set; }

    public double Slope { get; private set; }

    public double Derivative { get; private set; }

    public double InfiniteSlope { get; private set; }

    public double InfiniteDerivative { get; private set; }

    public double AtTheMoneyImpliedVolatility1Month { get; private set; } // TODO: review this; is this residual from the previous data provider?

    public double AtTheMoneyImpliedVolatility2Month { get; private set; }

    public double AtTheMoneyImpliedVolatility3Month { get; private set; }

    public double AtTheMoneyImpliedVolatility4Month { get; private set; }
}
