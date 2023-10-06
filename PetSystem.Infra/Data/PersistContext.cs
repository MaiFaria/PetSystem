using Microsoft.EntityFrameworkCore;

namespace PetSystem.Infra.Data;

public class PersistContext : DbContext
{
    protected PersistContext() { }

    public PersistContext(DbContextOptions<PersistContext> options)
        : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging()
                      .EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}