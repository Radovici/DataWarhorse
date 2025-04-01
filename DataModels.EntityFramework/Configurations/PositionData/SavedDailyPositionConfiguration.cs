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
    public class SavedDailyPositionConfiguration : IEntityTypeConfiguration<SavedDailyPosition>
    {
        public void Configure(EntityTypeBuilder<SavedDailyPosition> entity)
        {
            entity.HasKey(e => new { e.FundId, e.SecurityId, e.Date, e.CreateDateTime }).HasName("PK_DailyPositions");

            entity.ToTable("SavedDailyPositions", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Fund).WithMany(p => p.SavedDailyPositions)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyPositions_Funds");
        }
    }
}
