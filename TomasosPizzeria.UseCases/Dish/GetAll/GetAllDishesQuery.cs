using MediatR;

namespace TomasosPizzeria.UseCases.Dish.GetAll;

public record GetAllDishesQuery()  : IRequest<IEnumerable<Domain.Entities.Dish>>;