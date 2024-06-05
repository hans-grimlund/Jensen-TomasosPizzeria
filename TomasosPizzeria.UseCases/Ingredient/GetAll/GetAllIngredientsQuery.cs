using MediatR;

namespace TomasosPizzeria.UseCases.Ingredient.GetAll;

public record GetAllIngredientsQuery() : IRequest<IEnumerable<Domain.Entities.Ingredient>>;