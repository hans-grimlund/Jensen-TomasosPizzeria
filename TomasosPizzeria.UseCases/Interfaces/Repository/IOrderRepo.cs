using SharedKernel;

namespace TomasosPizzeria.UseCases.Interfaces.Repository;

public interface IOrderRepo
{
    Task<Response> AddOrder(Domain.Entities.Order order);
    Task<Response> ChangeOrderStatus(int id, string status);
    Task<Response> RemoveOrder(int id);

    Task<IEnumerable<Domain.Entities.Order>> GetOrdersFromUser(string userId);
    Task<IEnumerable<Domain.Entities.Order>> GetAllOrders();
    Task<Domain.Entities.Order> GetOrder(int id);
}