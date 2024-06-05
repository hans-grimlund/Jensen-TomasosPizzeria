using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.User.Update;

public record UpdateUserByIdCommand(string UserId, string? Username, string? Email, string? Phone) : IRequest<Response>;