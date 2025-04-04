using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class SecurityTypeConfiguration : IEntityTypeConfiguration<SecurityType>
    {
        public void Configure(EntityTypeBuilder<SecurityType> entity)
        {
            entity.ToTable("SecurityTypes", "dbo");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
