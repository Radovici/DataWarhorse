using DataModels.Interfaces;
using DataModels.MarketData;
using DataModels.PositionData;
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
