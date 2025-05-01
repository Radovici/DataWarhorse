using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> entity)
        {
            entity.ToTable("Trades", "dbo");

            entity.Property(e => e.TradeId).ValueGeneratedNever();
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.TradeDate).HasColumnType("smalldatetime").HasConversion(EquityPriceConfiguration.DateOnlyConverter);

            // NOTE: ignore these for now; we probably need them but they aren't mapped
            entity.Ignore(lmb => lmb.CurrencyId);
            entity.Ignore(lmb => lmb.Commission);

            entity.HasOne(d => d.Fund).WithMany(p => p.Trades)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trades_Funds");
        }
    }
}
