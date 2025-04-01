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
    public class SecurityAttributeConfiguration : IEntityTypeConfiguration<SecurityAttribute>
    {
        public void Configure(EntityTypeBuilder<SecurityAttribute> entity)
        {
            entity.HasKey(e => new { e.SecurityId, e.SecurityAttributeTypeId, e.Date });

            entity.ToTable("SecurityAttributes", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.SecurityAttributeType).WithMany(p => p.SecurityAttributes)
                .HasForeignKey(d => d.SecurityAttributeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecurityAttributes_SecurityAttributeTypes");

            entity.HasOne(d => d.Security).WithMany(p => p.SecurityAttributes)
                .HasForeignKey(d => d.SecurityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecurityAttributes_Securities");
        }
    }
}
