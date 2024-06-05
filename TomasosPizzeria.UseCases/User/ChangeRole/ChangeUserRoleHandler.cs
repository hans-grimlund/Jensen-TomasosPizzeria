using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.UseCases.User.ChangeRole;

public class ChangeUserRoleHandler(UserManager<ApplicationUser> userManager) 
    : IRequestHandler<ChangeUserRoleCommand, Response>
{
    public async Task<Response> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        if (user == null)
            return Response.NotFound;

        var currentRoles = await userManager.GetRolesAsync(user);
        var removeResult = userManager.RemoveFromRolesAsync(user, currentRoles);

        if (!removeResult.Result.Succeeded)
            return Response.Error;

        /*if (!await roleManager.RoleExistsAsync(request.Role))
            return Status.NotFound;*/

        var addResult = await userManager.AddToRoleAsync(user, request.Role);
        return addResult.Succeeded ? Response.Ok : Response.Error;
    }
}