using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class TargetConfiguration : IEntityTypeConfiguration<Target>
    {
        public void Configure(EntityTypeBuilder<Target> entity)
        {
            entity.ToTable("Targets", "dbo");

            entity.HasIndex(e => new { e.UserId, e.FundId, e.SecurityId, e.Formula, e.Date, e.CreateDateTime }, "UK_Targets").IsUnique();

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Formula)
                .HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes)
                .HasMaxLength(50);

            entity.HasOne(d => d.TargetDirection).WithMany(p => p.Targets)
                .HasForeignKey(d => d.TargetDirectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Targets_TargetDirections");
        }
    }
}
