using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> entity)
        {
            entity.ToTable("Securities", "dbo");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => new { e.Symbol, e.SecurityTypeId, e.ExchangeId, e.UnderlyingSecurityId }, "UK_Securities")
                .IsClustered()
                .IsUnique();

            entity.Property(e => e.CreateDateTime);

            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.SecurityType)
                .WithMany(p => p.Securities)
                .HasForeignKey(d => d.SecurityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Securities_SecurityTypes");
        }
    }
}
