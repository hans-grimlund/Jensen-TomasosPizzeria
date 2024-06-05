using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Category.Create;

public class CreateCategoryHandler(ICategoryRepo categoryRepo) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepo.AddCategory(new Domain.Entities.Category()
        {
            Name = request.Name
        });
    }
}