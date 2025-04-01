using DataModels.Interfaces;
using DataModels.MarketData;
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
    public class OptionPriceConfiguration : IEntityTypeConfiguration<OptionPrice>
    {
        public void Configure(EntityTypeBuilder<OptionPrice> entity)
        {
            entity.HasKey(e => new { e.SecurityId, e.Date });

            entity.ToTable("OptionPrices", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
        }
    }
}
