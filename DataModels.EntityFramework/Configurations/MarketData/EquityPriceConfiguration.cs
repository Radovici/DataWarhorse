using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class EquityPriceConfiguration : IEntityTypeConfiguration<EquityPrice>
    {
        public static ValueConverter DateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime)
            );

        public void Configure(EntityTypeBuilder<EquityPrice> entity)
        {
            // Configure the DateOnly property with a value converter
            var dateOnlyConverter =

            entity.HasKey(e => new { e.Date, e.SecurityId, e.SourceId });

            entity.ToTable("EquityPrices", "dbo");

            entity.Property(lmb => lmb.Date).HasColumnType("smalldatetime").HasConversion(EquityPriceConfiguration.DateOnlyConverter);
            entity.Property(lmb => lmb.CreateDateTime).HasColumnType("datetime");
            entity.Property(lmb => lmb.SourceId).HasColumnName("SourceId");

            entity.HasOne(lmb => lmb.Source)
                .WithMany()
                .HasForeignKey(lmb => lmb.SourceId)
                .HasConstraintName("FK_EquityPrice_Source");
        }
    }
}
