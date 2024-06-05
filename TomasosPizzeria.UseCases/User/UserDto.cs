namespace TomasosPizzeria.UseCases.User.GetProfile;

public record UserDto(string? Id, string? Email, string? Username, string? Phone, int Score, IEnumerable<string>? Roles);