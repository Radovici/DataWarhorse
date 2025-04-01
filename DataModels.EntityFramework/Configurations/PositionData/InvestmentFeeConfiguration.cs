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
    public class InvestmentFeeConfiguration : IEntityTypeConfiguration<InvestmentFee>
    {
        public void Configure(EntityTypeBuilder<InvestmentFee> entity)
        {
            entity.HasKey(e => new { e.InvestmentId, e.Date });

            entity.ToTable("InvestmentFees", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Fee).WithMany(p => p.InvestmentFees)
                .HasForeignKey(d => d.FeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvestmentFees_Fees");

            entity.HasOne(d => d.Investment).WithMany(p => p.InvestmentFees)
                .HasForeignKey(d => d.InvestmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvestmentFees_Investments");
        }
    }
}
