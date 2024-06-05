using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.UseCases.User.Login;

public class UserLoginHandler(UserManager<ApplicationUser> userManager, ITokenProvider tokenProvider) 
    : IRequestHandler<UserLoginQuery, UserLoginResponse>
{
    public async Task<UserLoginResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new UserLoginResponse(Response.NotFound, string.Empty);

        if (await userManager.CheckPasswordAsync(user, request.Password))
        {
            
            return new UserLoginResponse(Response.Ok, 
                tokenProvider.GenerateToken(user, await userManager.GetRolesAsync(user)));
        }

        return new UserLoginResponse(Response.Unauthorized, string.Empty);
    }
}