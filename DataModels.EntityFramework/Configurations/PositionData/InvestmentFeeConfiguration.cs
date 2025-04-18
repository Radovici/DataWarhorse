using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class InvestmentFeeConfiguration : IEntityTypeConfiguration<InvestmentFee>
    {
        public void Configure(EntityTypeBuilder<InvestmentFee> entity)
        {
            entity.HasKey(e => new { e.InvestmentId, e.Date });

            entity.ToTable("InvestmentFees", "dbo");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Fee).WithMany(p => p.InvestmentFees)
                .HasForeignKey(d => d.FeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvestmentFees_Fees");

            entity.HasOne(d => d.Investment).WithMany(p => p.InvestmentFees)
                .HasForeignKey(d => d.InvestmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvestmentFees_Investments");
        }
    }
}
