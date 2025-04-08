namespace DataModels.PositionData;

public partial class PortfolioOptimizationTrade
{
    public string OptimizationId { get; set; } = null!;

    public int RunIndex { get; set; }

    public int SecurityId { get; set; }

    public double Quantity { get; set; }

    public virtual PortfolioOptimization PortfolioOptimization { get; set; } = null!;
}
