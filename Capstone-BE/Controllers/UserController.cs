using Capstone_BE.DTOs;
using Capstone_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_BE.Controllers;

public class UserController(CapstoneDbContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDto>> GetUsersAsync()
    {
        var users = await context.Users.ToListAsync();
        List<UserDto> userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            userDtos.Add(userDto);
        }
        return Ok(userDtos);
    }
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> GetUserByIdAsync(short id)
    {
        var user = await context.Users.FindAsync(id);
        
        return user != null ? Ok(new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        }) : NotFound("User not found");
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> UpdateUserAsync([FromBody] User aUser, short id)
    {
        aUser.Id = id;
        context.Update(aUser);
        await context.SaveChangesAsync();

        return Ok(new UserDto
        {
            Id = aUser.Id,
            Username = aUser.Username,
            Email = aUser.Email,
            FirstName = aUser.FirstName,
            LastName = aUser.LastName,
            
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> DeleteUserAsync(short id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("User not found");
        }
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}