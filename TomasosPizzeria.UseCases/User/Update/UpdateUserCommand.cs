using System.Security.Claims;
using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.User.Update;

public record UpdateUserCommand(ClaimsPrincipal User, string? Username, string? Email, string? Phone) 
    : IRequest<Response>;