using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;

namespace SimpleBudgetTracker.Data.Contexts;

public partial class SimpleBudgetTrackerContext : DbContext, ISimpleBudgetTrackerContext
{
    public SimpleBudgetTrackerContext(DbContextOptions<SimpleBudgetTrackerContext> options): base(options)
    {

    }

    public DbSet<User> Users  =>  Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>()
            .ToTable("users");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasKey(e => e.Id);

            entity
                .HasOne(e => e.CreatedBy)
                .WithMany();

            entity
                .HasOne(e => e.UpdatedBy)
                .WithMany();
        });

    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}