using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Context;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.Infrastructure.Data.Repository;

public class CategoryRepo(TomasosContext context) : ICategoryRepo
{
    public async Task<Response> AddCategory(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return Response.Ok;
    }

    public async Task<Response> RemoveCategory(int categoryId)
    {
        var category = await context.Categories
            .FindAsync(categoryId);
        
        if (category == null)
            return Response.NotFound;

        context.Remove(category);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await context.Categories
            //.AsNoTracking()
            .ToListAsync();
    }
}
