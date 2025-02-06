using System.ComponentModel.DataAnnotations;
using Capstone_BE.Models;

namespace Capstone_BE.DTOs;

public class RegisterDto
{
    [Required]
    public required string   Username    { get; set; } = null!;
    [Required]
    public required string   Password    { get; set; } = null!;
    [Required]
    public required string   FirstName   { get; set; } = null!;
    [Required]
    public required string   LastName    { get; set; } = null!;
    [Required] 
    public required string   Email       { get; set; } = null!;
    [Required]
    public required List<Location> Locations   { get; set; } = null!;
}