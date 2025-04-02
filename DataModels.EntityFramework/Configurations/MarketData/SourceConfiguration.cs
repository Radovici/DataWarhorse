using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> entity)
        {
            entity.ToTable("Sources", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
