using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;
using System.Reflection.Emit;

namespace SimpleBudgetTracker.Data.Contexts;

public partial class SimpleBudgetTrackerContext : DbContext, ISimpleBudgetTrackerContext
{
    public SimpleBudgetTrackerContext(DbContextOptions<SimpleBudgetTrackerContext> options): base(options)
    {

    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 

        modelBuilder.HasDefaultSchema("sbt");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasKey(e => e.Id);

            entity
                .HasOne(e => e.CreatedBy)
                .WithMany();

            entity
                .HasOne(e => e.UpdatedBy)
                .WithMany();
        });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableDetailedErrors();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}