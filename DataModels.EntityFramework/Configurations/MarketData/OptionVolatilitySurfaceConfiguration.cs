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
    public class OptionVolatilitySurfaceConfiguration : IEntityTypeConfiguration<OptionVolatilitySurface>
    {
        public void Configure(EntityTypeBuilder<OptionVolatilitySurface> entity)
        {
            entity.HasKey(e => new { e.Date, e.SecurityId });

            entity.ToTable("OptionVolatilitySurfaces", "dbo");
        }
    }
}
