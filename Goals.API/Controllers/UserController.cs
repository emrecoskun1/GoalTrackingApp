using Creed.Common;
using Goals.Common.Dtos;
using Goals.Service;
using Microsoft.AspNetCore.Mvc;

namespace Goals.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class UserController:ControllerBase
{
    private UserService _userService;

    public UserController(UserService us)
    {
        _userService = us;
    }

    [HttpGet]
    public IActionResult GetUserByAuth(UserDto dto)
    {
        _userService.GetUsers();
        return Ok();
    }
    
    
}