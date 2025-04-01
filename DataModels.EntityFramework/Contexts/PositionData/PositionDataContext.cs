using System;
using System.Collections.Generic;
using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;

namespace DataModels.EntityFramework.PositionInformation.Contexts;

public partial class PositionDataContext
    : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REMOVED.ddns.net;Database=DataWarehouse;User Id=eldar;Password=REMOVED;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PositionDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
