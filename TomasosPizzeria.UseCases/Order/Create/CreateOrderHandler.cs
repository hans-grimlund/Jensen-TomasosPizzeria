using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Order.Create;

public class CreateOrderHandler(IOrderRepo orderRepo, IDishRepo dishRepo, IUserRepo userRepo,
    UserManager<ApplicationUser> userManager) : IRequestHandler<CreateOrderCommand, Response>
{
    public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.Order
        {
            ApplicationUser = await userManager.GetUserAsync(request.ClaimsPrincipal) 
                              ?? throw new NullReferenceException("User not found"),
            Status = "Pending"
        };
        var allDishes = await dishRepo.GetAllDishes(); 
        
        order.Dishes = request.Dishes
            .Select(dish => allDishes.FirstOrDefault(d => d.Id == dish))
            .OfType<Domain.Entities.Dish>()
            .ToList();

        if (order.Dishes.Count == 0)
            return Response.NotFound;

        order.Total = order.Dishes.Sum(dish => dish.Price);

        if (await userManager.IsInRoleAsync(order.ApplicationUser, "PremiumUser"))
        {
            if (order.ApplicationUser.Score >= 100)
            {
                order.Total -= order.Dishes.Min(d => d.Price);
                await userRepo.UpdateScore(order.ApplicationUser.Id, -100);
            }

            foreach (var dish in order.Dishes)
                await userRepo.UpdateScore(order.ApplicationUser.Id, 10);
            
            if (order.Dishes.Count >= 3)
                order.Discount = (decimal)0.8;
        }

        order.CalculateTotal();
        await orderRepo.AddOrder(order);
        return Response.Ok;
    }
}