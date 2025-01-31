using Capstone_BE.DTOs;
using Capstone_BE.Interfaces;
using Capstone_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_BE.Controllers;

public class AccountController(CapstoneDbContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UserDto>> RegisterAsync([FromBody]RegisterDto registerDto)
    {
        if (await UserExistsAsync(registerDto.Username))
        {
            return BadRequest("Username is taken");
        }

        if (await EmailExistsAsync(registerDto.Email))
        {
            return BadRequest("Email is taken");
        }
    
        var user = new User
        {
            Username = registerDto.Username.ToLower(),
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email
        };
    
        context.Users.Add(user);
        await context.SaveChangesAsync();

        var userDto = new UserDto
        {
            Id = user.Id,
            Username = registerDto.Username,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            Token = tokenService.CreateToken(user)
        };

        return Created("api/Account/register",userDto);
    }
    
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDto>> LoginAsync([FromBody] LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username != null && u.Username.ToLower() == loginDto.UserName.ToLower());

        if (user == null)
        {
            return Unauthorized("Username does not exist");
        }

        var password = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

        if (!password)
        {
            return Unauthorized("Invalid password");
        }
        
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }
    
    private async Task<bool> UserExistsAsync(string username)
    {
        return await context.Users.AnyAsync(u => u.Username != null && u.Username.ToLower() == username.ToLower());
    }
    
    private async Task<bool> EmailExistsAsync(string email)
    {
        return await context.Users.AnyAsync(u => u.Email == email);
    }
}