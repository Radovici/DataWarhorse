using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Countries", "dbo");

            entity.HasIndex(e => e.Name, "UK_Countries")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(50);
            entity.Property(e => e.SubRegion).HasMaxLength(50);

            entity.HasOne(lmb => lmb._currency) // if made public
                .WithMany()
                .HasForeignKey(lmb => lmb.CurrencyId) // again, if made public
                .HasConstraintName("FK_Countries_Currencies");
        }
    }
}
