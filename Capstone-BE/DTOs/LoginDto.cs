using System.ComponentModel.DataAnnotations;

namespace Capstone_BE.DTOs;

public class LoginDto
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}