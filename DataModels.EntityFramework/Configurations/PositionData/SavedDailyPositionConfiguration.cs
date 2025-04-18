using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
