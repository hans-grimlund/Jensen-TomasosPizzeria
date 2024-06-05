using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Ingredient.Create;

public class CreateIngredientHandler(IIngredientRepo ingredientRepo) : IRequestHandler<CreateIngredientCommand>
{
    public async Task Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        await ingredientRepo.AddIngredient(new Domain.Entities.Ingredient()
        {
            Name = request.Name
        });
    }
}