using SharedKernel;
using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.UseCases.Interfaces.Repository;

public interface IUserRepo
{
    Task<IEnumerable<ApplicationUser>> GetAllUsers();
    Task<Response> UpdateScore(string id, int score);
    Task<Response> UpdateUser(ApplicationUser user);
}
