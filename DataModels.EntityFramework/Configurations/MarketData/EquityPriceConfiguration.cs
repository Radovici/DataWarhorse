using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class EquityPriceConfiguration : IEntityTypeConfiguration<EquityPrice>
    {
        public void Configure(EntityTypeBuilder<EquityPrice> entity)
        {
            entity.HasKey(e => new { e.Date, e.SecurityId, e.SourceId });

            entity.ToTable("EquityPrices", "dbo");

            entity.Property(lmb => lmb.Date).HasColumnType("smalldatetime");
            entity.Property(lmb => lmb.CreateDateTime).HasColumnType("datetime");
            entity.Property(lmb => lmb.SourceId).HasColumnName("SourceId");

            entity.HasOne(lmb => lmb.Source)
                .WithMany()
                .HasForeignKey(lmb => lmb.SourceId)
                .HasConstraintName("FK_EquityPrice_Source");
        }
    }
}
