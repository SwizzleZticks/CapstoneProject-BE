using System.ComponentModel.DataAnnotations;

namespace Capstone_BE.DTOs;

public class UserDto
{
    [Required]
    public required short  Id        { get; set; }
    [Required]
    public required string? Username  { get; set; } = null!;
    [Required]
    public required string? FirstName { get; set; } = null!;
    [Required]
    public required string? LastName  { get; set; } = null!;
    [Required]
    public required string? Email     { get; set; } = null!;
    
    public string          Token     { get; set; } = null!;
}