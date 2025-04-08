using DataModels.EntityFramework.Contexts;
using DataModels.SecurityMaster;
using Microsoft.EntityFrameworkCore;

namespace DataModels.EntityFramework.SecurityMaster.Contexts;

public partial class SecurityMasterContext
    : ConfiguredDbContext
{
    public SecurityMasterContext()
    {
    }

    public SecurityMasterContext(DbContextOptions<SecurityMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<GicsId> GicsIds { get; set; }

    public virtual DbSet<Security> Securities { get; set; }

    public virtual DbSet<SecurityAttribute> SecurityAttributes { get; set; }

    public virtual DbSet<SecurityAttributeType> SecurityAttributeTypes { get; set; }

    public virtual DbSet<SecurityAttributeTypeAlias> SecurityAttributeTypeAliases { get; set; }

    public virtual DbSet<SecurityType> SecurityTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SecurityMasterContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
