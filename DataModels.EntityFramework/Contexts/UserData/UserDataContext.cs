using DataModels.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataModels.UserData.Contexts;

public partial class UserDataContext
    : ConfiguredDbContext
{
    public UserDataContext()
    {
    }

    public UserDataContext(DbContextOptions<UserDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomSecurityAttribute> CustomSecurityAttributes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
