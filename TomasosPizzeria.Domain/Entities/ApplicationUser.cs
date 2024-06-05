using Microsoft.AspNetCore.Identity;

namespace TomasosPizzeria.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public int Score { get; set; }
}