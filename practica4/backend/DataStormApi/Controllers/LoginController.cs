using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataStormApi.Data;
using DataStormApi.Models;

namespace DataStormApi.Controllers;
/*
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public LoginController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        User? user = await _userService.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return Unauthorized("Invalid credentials 1");
        }

        var saltedPassword = request.Password + user.Salt;

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, saltedPassword);

        if (result != PasswordVerificationResult.Success)
        {
            return Unauthorized("Invalid credentials 2");
        }

        // Generate token
        var token = _tokenService.CreateToken(user);

        // Return the token
        return Ok(new AuthResponse { Token = token });
    }
}
*/