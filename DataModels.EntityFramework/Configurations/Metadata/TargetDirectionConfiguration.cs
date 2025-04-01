using DataModels.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class TargetDirectionConfiguration : IEntityTypeConfiguration<TargetDirection>
    {
        public void Configure(EntityTypeBuilder<TargetDirection> entity)
        {
            entity.ToTable("TargetDirections", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
