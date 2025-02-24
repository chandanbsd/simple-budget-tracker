using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;

namespace SimpleBudgetTracker.Data.Contexts;

public partial class SimpleBudgetTrackerContext : ISimpleBudgetTrackerContext
{
    public bool IsUserNameUnique(string userName)
    {
        // TODO: Move to the newer username table
        return Users.Where(user => user.UserName == userName).Any();
    }
}
