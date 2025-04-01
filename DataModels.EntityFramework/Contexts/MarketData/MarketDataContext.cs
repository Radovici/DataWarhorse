using System;
using System.Collections.Generic;
using DataModels.MarketData;
using DataModels.EntityFramework.SecurityMaster.Contexts;
using Microsoft.EntityFrameworkCore;
using DataModels.SecurityMaster;

namespace DataModels.EntityFramework.MarketData.Contexts;

public partial class MarketDataContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REMOVED.ddns.net;Database=DataWarehouse;User Id=eldar;Password=REMOVED;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
