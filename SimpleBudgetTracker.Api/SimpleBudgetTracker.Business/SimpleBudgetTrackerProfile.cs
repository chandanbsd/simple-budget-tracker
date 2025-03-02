using AutoMapper;
using SimpleBudgetTracker.Data.Entities;
using SimpleBudgetTracker.Models.InputModels;

namespace SimpleBudgetTracker.Business;

public class SimpleBudgetTrackerProfile: Profile
{
    public SimpleBudgetTrackerProfile()
    {
        CreateMap<User, UserModel>();
    }
}
