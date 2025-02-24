using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;

namespace SimpleBudgetTracker.Data.Contexts;

public partial class SimpleBudgetTrackerContext : ISimpleBudgetTrackerContext
{
    public async Task<bool> IsUserNameUnique(string userName)
    {
        // TODO: Move to the newer username table
        var res = await Users.Where(user => user.UserName == userName).AnyAsync();
        return res;
    }
}
