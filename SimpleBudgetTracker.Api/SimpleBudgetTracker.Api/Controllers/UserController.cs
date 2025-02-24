using Microsoft.AspNetCore.Mvc;
using SimpleBudgetTracker.Business.Services.Interfaces;
using SimpleBudgetTracker.Models;

namespace SimpleBudgetTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private IUserService _userService;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<UserModel> CreateUser([FromBody] UserModel payload)
    {
        var res = await _userService.Create(payload);

        return res;
    }
}
