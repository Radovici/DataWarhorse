using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasKey(e => e.Id)
                .IsClustered(false);

            entity.ToTable("Countries", "dbo");

            entity.HasIndex(e => e.Name, "UK_Countries")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Name)
                .HasMaxLength(100);
            entity.Property(e => e.Region)
                .HasMaxLength(50);
            entity.Property(e => e.SubRegion)
                .HasMaxLength(50);

            entity.HasOne(lmb => lmb.Currency) // masked by ICountry's Currency
                .WithMany()
                .HasForeignKey(lmb => lmb.CurrencyId) // "internally" exposed
                .HasConstraintName("FK_Countries_Currencies");
        }
    }
}
