using DataModels.EntityFramework.Contexts;
using DataModels.Models.PositionData;
using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;

namespace DataModels.EntityFramework.PositionInformation.Contexts;

public partial class PositionDataContext
    : ConfiguredDbContext
{
    public PositionDataContext()
    {
    }

    public PositionDataContext(DbContextOptions<PositionDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<InvestmentFee> InvestmentFees { get; set; }

    public virtual DbSet<PortfolioOptimization> PortfolioOptimizations { get; set; }

    public virtual DbSet<PortfolioOptimizationTrade> PortfolioOptimizationTrades { get; set; }

    public virtual DbSet<SavedDailyPosition> SavedDailyPositions { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PositionDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
