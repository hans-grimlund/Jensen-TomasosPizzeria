using MediatR;
using SharedKernel;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Order.Remove;

public class RemoveOrderHandler(IOrderRepo orderRepo) 
    : IRequestHandler<RemoveOrderCommand, Response>
{
    public async Task<Response> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        if ((await orderRepo.GetOrder(request.Id)).Id == 0)
            return Response.NotFound;
        
        await orderRepo.RemoveOrder(request.Id);
        return Response.Ok;
    }
}