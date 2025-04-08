using DataModels.EntityFramework.Contexts;
using DataModels.MarketData;
using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;

namespace DataModels.EntityFramework.MarketData.Contexts;

public partial class MarketDataContext
    : ConfiguredDbContext
{
    public MarketDataContext()
    {
    }

    public MarketDataContext(DbContextOptions<MarketDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Security> Securities { get; set; }

    public virtual DbSet<EquityPrice> EquityPrices { get; set; }

    public virtual DbSet<EquitySplit> EquitySplits { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<OptionPrice> OptionPrices { get; set; }

    public virtual DbSet<OptionVolatilitySurface> OptionVolatilitySurfaces { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
