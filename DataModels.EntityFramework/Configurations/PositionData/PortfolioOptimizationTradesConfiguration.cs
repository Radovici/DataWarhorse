using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class PortfolioOptimizationTradeConfiguration : IEntityTypeConfiguration<PortfolioOptimizationTrade>
    {
        public void Configure(EntityTypeBuilder<PortfolioOptimizationTrade> entity)
        {
            entity.HasKey(e => new { e.OptimizationId, e.RunIndex, e.SecurityId, e.Quantity });

            entity.ToTable("PortfolioOptimizationTrades", "dbo");

            entity.Property(e => e.OptimizationId)
                .HasMaxLength(250);

            entity.HasOne(d => d.PortfolioOptimization).WithMany(p => p.PortfolioOptimizationTrades)
                .HasForeignKey(d => new { d.OptimizationId, d.RunIndex })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioOptimizationTrades_PortfolioOptimizations");
        }
    }
}
