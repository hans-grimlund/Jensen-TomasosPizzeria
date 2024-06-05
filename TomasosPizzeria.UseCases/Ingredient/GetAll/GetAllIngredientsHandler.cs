using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Ingredient.GetAll;

public class GetAllIngredientsHandler(IIngredientRepo ingredientRepo)
    : IRequestHandler<GetAllIngredientsQuery, IEnumerable<Domain.Entities.Ingredient>>
{
    public async Task<IEnumerable<Domain.Entities.Ingredient>> 
        Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        return await ingredientRepo.GetAllIngredients();
    }
}