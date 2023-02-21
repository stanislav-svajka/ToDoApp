using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppBE.Controllers;


[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class UserController :ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody, Bind] UserDto request, CancellationToken ct)
    {
        try
        {
            var user = new UserEntity()
            {
                Username = request.Username
            };
            var userId = await _userService.Register(user, request.Password);

            return Ok(userId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(
        [FromBody, Bind] UserDto request)
    {
        try
        {
            var user = await _userService.Login(request.Username, request.Password);
            return Ok(user);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
    
    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> TestAuth()
    {
        return Ok("si frajer");
    }
}