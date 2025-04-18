using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class OptionPriceConfiguration : IEntityTypeConfiguration<OptionPrice>
    {
        public void Configure(EntityTypeBuilder<OptionPrice> entity)
        {
            entity.HasKey(e => new { e.SecurityId, e.Date });

            entity.ToTable("OptionPrices", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
        }
    }
}
