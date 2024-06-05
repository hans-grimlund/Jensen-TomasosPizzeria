using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Category.GetAll;

public class GetAllCategoriesHandler(ICategoryRepo categoryRepo)
    : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Entities.Category>>
{
    public async Task<IEnumerable<Domain.Entities.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await categoryRepo.GetAllCategories();
    }
}