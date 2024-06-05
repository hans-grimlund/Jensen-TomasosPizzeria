using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Order.GetAll;

public class GetAllOrdersHandler(IOrderRepo orderRepo) 
    : IRequestHandler<GetAllOrdersQuery, IEnumerable<Domain.Entities.Order>>
{
    public async Task<IEnumerable<Domain.Entities.Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await orderRepo.GetAllOrders();
    }
}