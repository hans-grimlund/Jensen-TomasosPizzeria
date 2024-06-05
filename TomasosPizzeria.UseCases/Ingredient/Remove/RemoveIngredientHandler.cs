using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Ingredient.Remove;

public class RemoveIngredientHandler(IIngredientRepo ingredientRepo) : IRequestHandler<RemoveIngredientCommand>
{
    public async Task Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        await ingredientRepo.RemoveIngredient(request.Id);
    }
}