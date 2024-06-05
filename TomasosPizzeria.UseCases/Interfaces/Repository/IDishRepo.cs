using SharedKernel;

namespace TomasosPizzeria.UseCases.Interfaces.Repository;

public interface IDishRepo
{
    Task<Response> AddDish(Domain.Entities.Dish dish);
    Task<Response> UpdateDish(Domain.Entities.Dish dish);
    Task<Response> RemoveDish(int id);

    Task<IEnumerable<Domain.Entities.Dish>> GetAllDishes();
    Task<Domain.Entities.Dish> GetDish(int id);
}