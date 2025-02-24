using SimpleBudgetTracker.Models;

namespace SimpleBudgetTracker.Business.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> Create(UserModel payload);
}
