using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Dish.Create;

public class CreateDishHandler(IDishRepo dishRepo, IIngredientRepo ingredientRepo, ICategoryRepo categoryRepo) 
    : IRequestHandler<CreateDishCommand>
{
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var allIngredients = await ingredientRepo.GetAllIngredients();
        
        var ingredientMatches = request.Ingredients.Select(ingredient =>
            allIngredients.FirstOrDefault(i => i.Id == ingredient))
            .OfType<Domain.Entities.Ingredient>().ToList();

        if (ingredientMatches.Count == 0)
            return;

        var categoryMatch = (await categoryRepo.GetAllCategories())
            .FirstOrDefault(c => c.Id == request.Category);

        if (categoryMatch == null)
            return;

        await dishRepo.AddDish(new Domain.Entities.Dish()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.Category,
            Category = categoryMatch,
            Ingredients = ingredientMatches
            
        });
    }
}