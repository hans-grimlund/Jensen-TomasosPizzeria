using MediatR;
using SharedKernel;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Order.ChangeStatus;

public class ChangeOrderStatusHandler(IOrderRepo orderRepo) : IRequestHandler<ChangeOrderStatusCommand, Response>
{
    public async Task<Response> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
    {
        await orderRepo.ChangeOrderStatus(request.Id, request.Status);
        return Response.Ok;
    }
}