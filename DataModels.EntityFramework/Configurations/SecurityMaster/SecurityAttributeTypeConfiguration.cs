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
    public class SecurityAttributeTypeConfiguration : IEntityTypeConfiguration<SecurityAttributeType>
    {
        public void Configure(EntityTypeBuilder<SecurityAttributeType> entity)
        {
            entity.ToTable("SecurityAttributeTypes", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
