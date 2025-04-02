using DataModels.UserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModels.EntityFramework.Configurations.SecurityMaster
{
    public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> entity)
        {
            entity.ToTable("UserSessions", "dbo");

            entity.Property(e => e.Comment)
                .HasMaxLength(100);
            entity.Property(e => e.Expiration).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSessions_Users");
        }
    }
}
