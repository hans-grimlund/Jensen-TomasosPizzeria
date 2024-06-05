using SharedKernel;

namespace TomasosPizzeria.UseCases.Interfaces.Repository;

public interface IIngredientRepo
{
    Task<Response> AddIngredient(Domain.Entities.Ingredient ingredient);
    Task<Response> RemoveIngredient(int id);

    Task<IEnumerable<Domain.Entities.Ingredient>> GetAllIngredients();
}