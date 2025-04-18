using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> entity)
        {
            entity.ToTable("Investments", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Fund).WithMany(p => p.Investments)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Investments_Funds");
        }
    }
}
