using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.ToTable("Currencies", "dbo");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
