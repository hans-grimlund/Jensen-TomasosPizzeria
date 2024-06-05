using MediatR;

namespace TomasosPizzeria.UseCases.User.Create;

public record CreateUserCommand(string Username, string Password, string Email, string Phone) : IRequest<string>;