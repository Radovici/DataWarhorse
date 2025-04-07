namespace DataModels.PositionData;

public partial class Fee
{
    public int Id { get; private set; }

    public double ManagementFee { get; private set; }

    public double PerformanceFee { get; private set; }

    public virtual ICollection<InvestmentFee> InvestmentFees { get; private set; } = new List<InvestmentFee>();
}
