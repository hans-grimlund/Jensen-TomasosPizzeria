using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.Infrastructure.Context;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.Infrastructure.Data.Repository;

public class OrderRepo(TomasosContext context) : IOrderRepo
{
    public async Task<Response> AddOrder(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<Response> ChangeOrderStatus(int id, string status)
    {
        var order = await context.Orders
            .FindAsync(id);
    
        if (order == null)
            return Response.NotFound;

        order.Status = status;
    
        await context.SaveChangesAsync();
        return Response.Ok;
    }

    public async Task<Response> RemoveOrder(int id)
    {
        var order = await context.Orders
            .FindAsync(id);
        
        if (order == null)
            return Response.NotFound;

        context.Orders.Remove(order);
        await context.SaveChangesAsync();

        return Response.Ok;
    }

    public async Task<IEnumerable<Order>> GetOrdersFromUser(string userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user == null)
            return [];
        
        return await context.Orders
            //.AsNoTracking()
            .Include(o => o.Dishes)
                .ThenInclude(d => d.Category)
            .Include(o => o.ApplicationUser)
            .Where(o => o.ApplicationUser.Id == user.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await context.Orders
            //.AsNoTracking()
            .Include(o => o.Dishes)
                .ThenInclude(d => d.Category)
            .Include(o => o.ApplicationUser)
            .ToListAsync();
    }

    public async Task<Order> GetOrder(int id)
    {
        return await context.Orders.FirstOrDefaultAsync(o => o.Id == id)
               ?? new Order();
    }
}