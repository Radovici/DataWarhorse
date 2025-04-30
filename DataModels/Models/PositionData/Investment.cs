namespace DataModels.PositionData;

public partial class Investment
{
    public int Id { get; set; }

    public int FundId { get; set; }

    public DateOnly Date { get; set; }

    public double Change { get; set; }

    public virtual Fund Fund { get; set; } = null!;

    public virtual ICollection<InvestmentFee> InvestmentFees { get; set; } = new List<InvestmentFee>();
}
