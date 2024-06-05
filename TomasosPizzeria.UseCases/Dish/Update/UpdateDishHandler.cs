using MediatR;
using SharedKernel;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Dish.Update;

public class UpdateDishHandler(IDishRepo dishRepo, IIngredientRepo ingredientRepo) : IRequestHandler<UpdateDishCommand, Response>
{
    public async Task<Response> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    {
        var original = await dishRepo.GetDish(request.Id);
        if (original.Id == 0)
            return Response.NotFound;

        var allIngredients = await ingredientRepo.GetAllIngredients();
        
        foreach (var ingredient in request.Ingredients)
        {
            var match = allIngredients.FirstOrDefault(i => i.Id == ingredient);
            if (match != null)
                original.Ingredients.Add(match);
        }

        if (request.Name != null) original.Name = request.Name;
        if (request.Description != null) original.Description = request.Description;
        if (request.Price != 0) original.Price = request.Price;
        if (request.CategoryId != 0) original.CategoryId = request.CategoryId;

        await dishRepo.UpdateDish(original);
        return Response.Ok;
    }
}