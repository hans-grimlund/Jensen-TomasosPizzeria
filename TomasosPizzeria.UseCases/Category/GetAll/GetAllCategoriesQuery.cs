using MediatR;

namespace TomasosPizzeria.UseCases.Category.GetAll;

public record GetAllCategoriesQuery() : IRequest<IEnumerable<Domain.Entities.Category>>;