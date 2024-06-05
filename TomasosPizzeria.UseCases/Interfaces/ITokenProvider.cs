using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.UseCases.Interfaces;

public interface ITokenProvider
{
    string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}