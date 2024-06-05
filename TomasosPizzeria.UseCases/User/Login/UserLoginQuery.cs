using MediatR;

namespace TomasosPizzeria.UseCases.User.Login;

public record UserLoginQuery(string Email, string Password) : IRequest<UserLoginResponse>;