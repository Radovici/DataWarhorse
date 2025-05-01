using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class PriceTargetConfiguration : IEntityTypeConfiguration<PriceTarget>
    {
        public void Configure(EntityTypeBuilder<PriceTarget> entity)
        {
            entity.ToTable("PriceTargets", "dbo");

            entity.HasIndex(e => new { e.UserId, e.SecurityId, e.TargetDate, e.Notes }, "UK_PriceTargets").IsUnique();

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes)
                .HasMaxLength(50);
            entity.Property(e => e.TargetDate).HasColumnType("smalldatetime").HasConversion(EquityPriceConfiguration.DateOnlyConverter);
        }
    }
}
