using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SimpleBudgetTracker.Data.Entities;

namespace SimpleBudgetTracker.Data.Contexts.Interfaces;

public partial interface ISimpleBudgetTrackerContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    DatabaseFacade Database { get; }
}
