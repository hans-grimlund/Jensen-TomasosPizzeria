using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Category.Remove;

public class RemoveCategoryHandler(ICategoryRepo categoryRepo) : IRequestHandler<RemoveCategoryCommand>
{
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepo.RemoveCategory(request.CategoryId);
    }
}