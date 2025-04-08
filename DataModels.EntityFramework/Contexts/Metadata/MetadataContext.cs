using DataModels.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Metadata.Contexts;

public partial class MetadataContext : ConfiguredDbContext
{
    public MetadataContext()
    {
    }

    public MetadataContext(DbContextOptions<MetadataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PriceTarget> PriceTargets { get; set; }

    public virtual DbSet<PriceTargetNotification> PriceTargetNotifications { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<TargetDirection> TargetDirections { get; set; }

    public virtual DbSet<TargetNotification> TargetNotifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetadataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
