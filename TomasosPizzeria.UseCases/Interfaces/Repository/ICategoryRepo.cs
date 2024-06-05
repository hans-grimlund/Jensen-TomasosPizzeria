using SharedKernel;

namespace TomasosPizzeria.UseCases.Interfaces.Repository;

public interface ICategoryRepo
{
    Task<Response> AddCategory(Domain.Entities.Category category);
    Task<Response> RemoveCategory(int categoryId);

    Task<IEnumerable<Domain.Entities.Category>> GetAllCategories();
}