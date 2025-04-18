using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class PortfolioOptimizationConfiguration : IEntityTypeConfiguration<PortfolioOptimization>
    {
        public void Configure(EntityTypeBuilder<PortfolioOptimization> entity)
        {
            entity.HasKey(e => new { e.OptimizationId, e.RunIndex });

            entity.ToTable("PortfolioOptimizations", "dbo");

            entity.Property(e => e.OptimizationId)
                .HasMaxLength(250);
            entity.Property(e => e.ScoreFunction)
                .HasMaxLength(50);

            entity.HasOne(d => d.Fund).WithMany(p => p.PortfolioOptimizations)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioOptimizations_Funds");
        }
    }
}
