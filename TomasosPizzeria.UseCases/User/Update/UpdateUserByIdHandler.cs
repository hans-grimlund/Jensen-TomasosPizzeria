using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.User.Update;

public class UpdateUserByIdHandler(UserManager<ApplicationUser> userManager, IUserRepo userRepo) 
    : IRequestHandler<UpdateUserByIdCommand, Response>
{
    public async Task<Response> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return Response.NotFound;

        await userManager.SetEmailAsync(user, request.Email);
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await userManager.ConfirmEmailAsync(user, token);

        await userManager.SetUserNameAsync(user, request.Username);
        await userManager.SetPhoneNumberAsync(user, request.Phone);

        await userRepo.UpdateUser(user);
        return Response.Ok;
    }
}