using MediatR;
using Microsoft.AspNetCore.Identity;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces.Repository;
using TomasosPizzeria.UseCases.User.GetProfile;

namespace TomasosPizzeria.UseCases.User.GetAll;

public class GetAllUsersHandler(IUserRepo userRepo, UserManager<ApplicationUser> userManager) 
    : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepo.GetAllUsers();
        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            userDtos.Add(new UserDto(user.Id, user.Email, user.UserName, user.PhoneNumber, user.Score,
                await userManager.GetRolesAsync(user)));
        }

        return userDtos;
    }
}