using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsCookin.Dtos;
using WhatsCookin.Services.TokenService;
using WhatsCookin.Services.UserService;

namespace WhatsCookin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpGet, Authorize]
    public ActionResult<string> GetMe()
    {
        var username = _userService.GetMyName();
        return Ok(username);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto request)
    {
        try
        {
            var user = _userService.RegisterUser(request);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto request)
    {
        try
        {
            var user = _userService.LoginUser(request);
            var token = _tokenService.CreateToken(user);
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
