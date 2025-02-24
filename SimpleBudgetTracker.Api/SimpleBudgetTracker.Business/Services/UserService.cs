using Microsoft.Extensions.Logging;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;

namespace SimpleBudgetTracker.Business.Services;

internal class UserService
{
    private readonly ILogger<UserService> _logger;

    private ISimpleBudgetTrackerContext _dbContext;

    public UserService(
        ILogger<UserService> logger,
        ISimpleBudgetTrackerContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async void Create(
        string userName,
        string firstName,
        string lastName,
        int createdById,
        int updatedById)
    {

        if (!string.IsNullOrWhiteSpace(userName) && await _dbContext.IsUserNameUnique(userName) )
        {
            throw new Exception("Unable to assign the username. Please try another username!");
        }

        User user = User.Create(
            userName,
            firstName,
            lastName,
            createdById,
            updatedById);

        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            // Assuming _dbContext has a Users DbSet property
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(false);
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the user.");
            await transaction.RollbackAsync();
        }
    }
}
