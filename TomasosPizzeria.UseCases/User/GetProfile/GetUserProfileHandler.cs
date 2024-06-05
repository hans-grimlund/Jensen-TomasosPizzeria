using MediatR;
using Microsoft.AspNetCore.Identity;
using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.UseCases.User.GetProfile;

public class GetUserProfileHandler(UserManager<ApplicationUser> userManager) 
    : IRequestHandler<GetUserProfileQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(request.ClaimsPrincipal);
        if (user == null)
            return null!;
        
        var roles = await userManager.GetRolesAsync(user);
        
        return new UserDto(user.Id, user.Email, user.UserName, user.PhoneNumber, user.Score, roles);
    }
}