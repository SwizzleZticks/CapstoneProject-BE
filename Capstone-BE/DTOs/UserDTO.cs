using System.ComponentModel.DataAnnotations;

namespace Capstone_BE.DTOs;

public class UserDTO
{
    [Required]
    public required short Id { get; set; }
    [Required]
    public required string? Username { get; set; }
    [Required]
    public required string? FirstName { get; set; }
    [Required]
    public required string? LastName { get; set; }
    [Required]
    public required string? Email { get; set; }
}