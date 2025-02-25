using AutoMapper;
using Microsoft.Extensions.Logging;
using SimpleBudgetTracker.Business.Constants;
using SimpleBudgetTracker.Business.Services.Interfaces;
using SimpleBudgetTracker.Data.Contexts;
using SimpleBudgetTracker.Data.Contexts.Interfaces;
using SimpleBudgetTracker.Data.Entities;
using SimpleBudgetTracker.Models.OutputModels;

namespace SimpleBudgetTracker.Business.Services;

public class UserService: IUserService
{
    private readonly ILogger<UserService> _logger;

    private readonly IMapper _mapper;

    private SimpleBudgetTrackerContext _dbContext;

    public UserService(
        ILogger<UserService> logger,
        SimpleBudgetTrackerContext dbContext,
        IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserModel> Create(SimpleBudgetTracker.Models.InputModels.UserModel payload)
    {

        //if (!string.IsNullOrWhiteSpace(payload.UserName) && await _dbContext.IsUserNameUnique(payload.UserName) )
        //{
        //    throw new Exception("Unable to assign the username. Please try another username!");
        //}

        User user = User.Create(
            payload.UserName,
            payload.FirstName,
            payload.LastName,
            SystemConstants.ApiUserId);

        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            // Assuming _dbContext has a Users DbSet property
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(false);
            await transaction.CommitAsync();

            return _mapper.Map<User, UserModel>(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the user.");
            await transaction.RollbackAsync();

            throw new Exception("Failed to create user");
        }
    }
}
