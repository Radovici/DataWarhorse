namespace DataModels.MarketData;

public partial class OptionVolatilitySurface {
    public int SecurityId { get; set; }

    public DateOnly Date { get; set; }

    public double Slope { get; set; }

    public double Derivative { get; set; }

    public double InfiniteSlope { get; set; }

    public double InfiniteDerivative { get; set; }

    public double AtTheMoneyImpliedVolatility1Month { get; set; } // TODO: review this; is this residual from the previous data provider?

    public double AtTheMoneyImpliedVolatility2Month { get; set; }

    public double AtTheMoneyImpliedVolatility3Month { get; set; }

    public double AtTheMoneyImpliedVolatility4Month { get; set; }
}
