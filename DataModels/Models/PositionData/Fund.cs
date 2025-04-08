using DataModels.Interfaces;

namespace DataModels.PositionData;

public partial class Fund : IFund
{
    public static IFund Null = new Fund() { Id = 0 };

    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public bool Delete { get; set; }

    public virtual ICollection<Investment> Investments { get; set; } = new List<Investment>();

    public virtual ICollection<PortfolioOptimization> PortfolioOptimizations { get; set; } = new List<PortfolioOptimization>();

    public virtual ICollection<SavedDailyPosition> SavedDailyPositions { get; set; } = new List<SavedDailyPosition>();

    public virtual ICollection<Trade> Trades { get; set; } = new List<Trade>();
}
