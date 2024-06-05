using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Context;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.Infrastructure.Data.Repository;

public class IngredientRepo(TomasosContext context) : IIngredientRepo
{
    public async Task<Response> AddIngredient(Ingredient ingredient)
    {
        await context.Ingredients.AddAsync(ingredient);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<Response> RemoveIngredient(int id)
    {
        var ingredient = await context.Ingredients
            .FindAsync(id);
        
        if (ingredient == null)
            return Response.NotFound;

        context.Ingredients.Remove(ingredient);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<IEnumerable<Ingredient>> GetAllIngredients()
    {
        return await context.Ingredients
            //.AsNoTracking()
            .ToListAsync();
    }
}