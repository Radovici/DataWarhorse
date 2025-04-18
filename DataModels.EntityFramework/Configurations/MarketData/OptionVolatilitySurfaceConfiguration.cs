using DataModels.MarketData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class OptionVolatilitySurfaceConfiguration : IEntityTypeConfiguration<OptionVolatilitySurface>
    {
        public void Configure(EntityTypeBuilder<OptionVolatilitySurface> entity)
        {
            entity.HasKey(e => new { e.Date, e.SecurityId });

            entity.ToTable("OptionVolatilitySurfaces", "dbo");
        }
    }
}
