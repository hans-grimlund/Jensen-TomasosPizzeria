using MediatR;
using Microsoft.AspNetCore.Identity;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Order.GetFromUser;

public class GetOrdersFromUserHandler(IOrderRepo orderRepo, UserManager<ApplicationUser> userManager) 
    : IRequestHandler<GetOrdersFromUserQuery, IEnumerable<Domain.Entities.Order>>
{
    public async Task<IEnumerable<Domain.Entities.Order>> Handle(GetOrdersFromUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(request.ClaimsPrincipal);
        if (user == null)
            return [];
        
        return await orderRepo.GetOrdersFromUser(user.Id);
    }
}