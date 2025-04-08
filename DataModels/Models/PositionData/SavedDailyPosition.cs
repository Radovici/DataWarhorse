namespace DataModels.PositionData;

public partial class SavedDailyPosition
{
    public int FundId { get; set; }

    public int SecurityId { get; set; }

    public DateTime Date { get; set; }

    public double StartQuantity { get; set; }

    public double EndQuantity { get; set; }

    public bool IsLong { get; set; }

    public double Pnl { get; set; }

    public double StartMarketValue { get; set; }

    public double EndMarketValue { get; set; }

    public double OpenMarketValue { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Fund Fund { get; set; } = null!;
}
