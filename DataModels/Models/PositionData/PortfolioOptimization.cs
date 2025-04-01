namespace DataModels.PositionData;

public partial class PortfolioOptimization {
    public string OptimizationId { get; set; } = null!;

    public int RunIndex { get; set; }

    public int FundId { get; set; }

    public DateOnly Date { get; set; }

    public string ScoreFunction { get; set; } = null!;

    public double Score { get; set; }

    public virtual Fund Fund { get; set; } = null!;

    public virtual ICollection<PortfolioOptimizationTrade> PortfolioOptimizationTrades { get; set; } = new List<PortfolioOptimizationTrade>();
}
