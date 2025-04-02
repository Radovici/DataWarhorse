using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class GicsIdConfiguration : IEntityTypeConfiguration<GicsId>
    {
        public void Configure(EntityTypeBuilder<GicsId> entity)
        {
            entity.ToTable("GicsIds", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(100);
        }
    }
}
