namespace DataModels.PositionData;

public partial class Fee {
    public int Id { get; set; }

    public double ManagementFee { get; set; }

    public double PerformanceFee { get; set; }

    public virtual ICollection<InvestmentFee> InvestmentFees { get; set; } = new List<InvestmentFee>();
}
