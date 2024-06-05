using System.Security.Claims;
using MediatR;

namespace TomasosPizzeria.UseCases.User.GetProfile;

public record GetUserProfileQuery(ClaimsPrincipal ClaimsPrincipal) : IRequest<UserDto>;