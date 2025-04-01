using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class PriceTargetNotificationConfiguration : IEntityTypeConfiguration<PriceTargetNotification>
    {
        public void Configure(EntityTypeBuilder<PriceTargetNotification> entity)
        {
            entity.ToTable("PriceTargetNotifications", "dbo");

            entity.HasIndex(e => new { e.PriceTargetId, e.CreateDateTime }, "UK_PriceTargetNotifications").IsUnique();

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PriceTarget).WithMany(p => p.PriceTargetNotifications)
                .HasForeignKey(d => d.PriceTargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PriceTargetNotifications_PriceTargets");
        }
    }
}
