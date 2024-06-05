using System.Security.Claims;
using MediatR;

namespace TomasosPizzeria.UseCases.Order.GetFromUser;

public record GetOrdersFromUserQuery(ClaimsPrincipal ClaimsPrincipal) : IRequest<IEnumerable<Domain.Entities.Order>>;