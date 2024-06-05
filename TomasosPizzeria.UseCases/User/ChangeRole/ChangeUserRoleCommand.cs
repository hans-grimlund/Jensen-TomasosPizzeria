using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.User.ChangeRole;

public record ChangeUserRoleCommand(string Role, string Id) : IRequest<Response>;