using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Context;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.Infrastructure.Data.Repository;

public class UserRepo(TomasosContext context) : IUserRepo
{
    public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
    {
        return await context.Users
            ////.AsNoTracking()
            .ToListAsync();
    }

    public async Task<Response> UpdateScore(string id, int score)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
            return Response.NotFound;

        user.Score += score;
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<Response> UpdateUser(ApplicationUser user)
    {
        var original = await context.Users.FindAsync(user.Id);
        context.Entry(original).CurrentValues.SetValues(user);
        await context.SaveChangesAsync();

        return Response.Ok;
    }
}