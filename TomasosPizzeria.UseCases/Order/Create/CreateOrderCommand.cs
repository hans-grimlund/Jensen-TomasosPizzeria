using System.Security.Claims;
using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.Order.Create;

public record CreateOrderCommand(ClaimsPrincipal ClaimsPrincipal, IEnumerable<int> Dishes) : IRequest<Response>;