using DataModels.Interfaces;
using DataModels.MarketData;
using DataModels.PositionData;
using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class PortfolioOptimizationTradeConfiguration : IEntityTypeConfiguration<PortfolioOptimizationTrade>
    {
        public void Configure(EntityTypeBuilder<PortfolioOptimizationTrade> entity)
        {
            entity.HasKey(e => new { e.OptimizationId, e.RunIndex, e.SecurityId, e.Quantity });

            entity.ToTable("PortfolioOptimizationTrades", "dbo");

            entity.Property(e => e.OptimizationId)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.PortfolioOptimization).WithMany(p => p.PortfolioOptimizationTrades)
                .HasForeignKey(d => new { d.OptimizationId, d.RunIndex })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortfolioOptimizationTrades_PortfolioOptimizations");
        }
    }
}
