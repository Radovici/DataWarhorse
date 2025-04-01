using DataModels.Interfaces;
using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class SecurityAttributeTypeAliasConfiguration : IEntityTypeConfiguration<SecurityAttributeTypeAlias>
    {
        public void Configure(EntityTypeBuilder<SecurityAttributeTypeAlias> entity)
        {
            entity.HasKey(e => new { e.SecurityAttributeTypeId, e.Name, e.Source });

            entity.ToTable("SecurityAttributeTypeAliases", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.SecurityAttributeType).WithMany(p => p.SecurityAttributeTypeAliases)
                .HasForeignKey(d => d.SecurityAttributeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecurityAttributeTypeAliases_SecurityAttributeTypes");
        }
    }
}
