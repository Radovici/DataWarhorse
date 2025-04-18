using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class EquitySplitConfiguration : IEntityTypeConfiguration<EquitySplit>
    {
        public void Configure(EntityTypeBuilder<EquitySplit> entity)
        {
            entity.HasKey(e => new { e.SecurityId, e.Date });

            entity.ToTable("EquitySplits", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
        }
    }
}
