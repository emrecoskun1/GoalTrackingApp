using Goals.Service;
using Microsoft.AspNetCore.Mvc;

namespace Goals.API.Controllers;

public class UserController:ControllerBase
{
    private UserService _userService;

    public UserController(UserService us)
    {
        _userService = us;
    }

    public IActionResult Get()
    {
        _userService.GetUsers();
        return Ok();
    }
    
    
}