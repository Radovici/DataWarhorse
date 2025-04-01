using DataModels.UserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class CustomSecurityAttributeConfiguration : IEntityTypeConfiguration<CustomSecurityAttribute>
    {
        public void Configure(EntityTypeBuilder<CustomSecurityAttribute> entity)
        {
            entity.HasKey(e => new { e.UserId, e.SecurityId, e.SecurityAttributeTypeId, e.Date });

            entity.ToTable("CustomSecurityAttributes", "dbo");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.CustomSecurityAttributes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomSecurityAttributes_Users");
        }
    }
}
