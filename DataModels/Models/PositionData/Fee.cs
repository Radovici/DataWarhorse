using DataModels.PositionData;

namespace DataModels.Models.PositionData;

public partial class Fee // TODO: I would like to code this differently, more dynamic (there will be more fee types like hurdles and waterfalls)
{
    public int Id { get; private set; }

    public double ManagementFee { get; private set; }

    public double PerformanceFee { get; private set; }

    public virtual ICollection<InvestmentFee> InvestmentFees { get; private set; } = new List<InvestmentFee>();
}
