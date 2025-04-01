using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> entity)
        {
            entity.ToTable("Exchanges", "dbo");

            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ExchangeCode).HasMaxLength(10);
            entity.Property(e => e.FigiCode).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.Property("_countryId").HasColumnName("CountryId");

            entity.HasOne("_country")
                .WithMany()
                .HasForeignKey("_countryId")
                .HasConstraintName("FK_Exchange_Country");
        }
    }
}
