using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class TargetNotificationConfiguration : IEntityTypeConfiguration<TargetNotification>
    {
        public void Configure(EntityTypeBuilder<TargetNotification> entity)
        {
            entity.ToTable("TargetNotifications", "dbo");

            entity.HasIndex(e => new { e.TargetId, e.CreateDateTime }, "UK_TargetNotifications").IsUnique();

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Target).WithMany(p => p.TargetNotifications)
                .HasForeignKey(d => d.TargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetNotifications_Targets");
        }
    }
}
