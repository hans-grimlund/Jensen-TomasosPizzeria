using MediatR;

namespace TomasosPizzeria.UseCases.Order.GetAll;

public record GetAllOrdersQuery() : IRequest<IEnumerable<Domain.Entities.Order>>;