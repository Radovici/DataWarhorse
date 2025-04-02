using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class SecurityAttributeTypeConfiguration : IEntityTypeConfiguration<SecurityAttributeType>
    {
        public void Configure(EntityTypeBuilder<SecurityAttributeType> entity)
        {
            entity.ToTable("SecurityAttributeTypes", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
