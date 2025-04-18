using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class FundConfiguration : IEntityTypeConfiguration<Fund>
    {
        public void Configure(EntityTypeBuilder<Fund> entity)
        {
            entity.ToTable("Funds", "dbo");

            entity.Property(e => e.DisplayName)
                .HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(100);
        }
    }
}
