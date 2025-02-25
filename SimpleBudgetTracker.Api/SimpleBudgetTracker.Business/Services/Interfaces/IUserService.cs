using SimpleBudgetTracker.Models.OutputModels;

namespace SimpleBudgetTracker.Business.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> Create(SimpleBudgetTracker.Models.InputModels.UserModel payload);
}
