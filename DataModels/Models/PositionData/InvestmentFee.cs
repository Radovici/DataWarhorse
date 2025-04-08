using DataModels.Models.PositionData;

namespace DataModels.PositionData;

public partial class InvestmentFee
{
    public int InvestmentId { get; set; }

    public int FeeId { get; set; }

    public DateTime Date { get; set; }

    public virtual Fee Fee { get; set; } = null!;

    public virtual Investment Investment { get; set; } = null!;
}
