using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Context;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.Infrastructure.Data.Repository;

public class DishRepo(TomasosContext context) : IDishRepo
{
    public async Task<Response> AddDish(Dish dish)
    {
        await context.Dishes.AddAsync(dish);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<Response> UpdateDish(Dish dish)
    {
        var original = await context.Dishes
            .Include(d => d.Ingredients)
            .FirstOrDefaultAsync(d => d.Id == dish.Id);

        if (original == null)
            return Response.NotFound;

        context.Entry(original).CurrentValues.SetValues(dish);

        foreach (var existingIngredient in original.Ingredients
                     .ToList()
                     .Where(existingIngredient => dish.Ingredients
                         .All(i => i.Id != existingIngredient.Id)))
        {
            original.Ingredients.Remove(existingIngredient);
        }

        foreach (var newIngredient in dish.Ingredients)
        {
            var existingIngredient = original.Ingredients
                .FirstOrDefault(i => i.Id == newIngredient.Id);

            if (existingIngredient == null)
                original.Ingredients.Add(newIngredient);
            else
                context.Entry(existingIngredient).CurrentValues.SetValues(newIngredient);
        }

        await context.SaveChangesAsync();

        return Response.Ok;
    }


    public async Task<Response> RemoveDish(int id)
    {
        var dish = await context.Dishes
            .FindAsync(id);
        
        if (dish == null)
            return Response.NotFound;
        
        context.Dishes.Remove(dish);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<IEnumerable<Dish>> GetAllDishes()
    {
        return await context.Dishes
            .Include(d => d.Ingredients)
            .Include(d => d.Category)
            //.AsNoTracking()
            .ToListAsync();
    }

    public async Task<Dish> GetDish(int id)
    {
        return await context.Dishes
                   //.AsNoTracking()
                   .FirstOrDefaultAsync(d => d.Id == id)
            ?? new Dish();
    }
}