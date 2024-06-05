using MediatR;
using Microsoft.AspNetCore.Identity;
using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.UseCases.User.Create;

public class CreateUserHandler(UserManager<ApplicationUser> userManager) 
    : IRequestHandler<CreateUserCommand, string>
{
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser()
        {
            UserName = request.Username,
            Email = request.Email,
            PhoneNumber = request.Phone,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return string.Join(" ", result.Errors.Select(x => x.Description));

        await userManager.AddToRoleAsync(user, "RegularUser");
        
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await userManager.ConfirmEmailAsync(user, token);
        
        return string.Empty;
    }
}