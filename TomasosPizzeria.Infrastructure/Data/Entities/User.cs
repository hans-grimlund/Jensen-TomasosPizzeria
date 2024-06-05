/*using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TomasosPizzeria.Domain.Enums;
using TomasosPizzeria.Domain.Interfaces.Entities;

namespace TomasosPizzeria.Infrastructure.Data.Entities;

public class User : IdentityUser, IUser
{
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(10)]
    public string Phone { get; set; } = string.Empty;
    
    public Role Role { get; set; }
}*/