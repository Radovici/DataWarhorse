using System;
using System.Collections.Generic;
using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Metadata.Contexts;

public partial class MetadataContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=radovici.ddns.net;Database=DataWarehouse;User Id=eldar;Password=radovici;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetadataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
