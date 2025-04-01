using Microsoft.EntityFrameworkCore;

namespace DataModels.UserData.Contexts;

public partial class UserDataContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REMOVED.ddns.net;Database=DataWarehouse;User Id=eldar;Password=REMOVED;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDataContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
