using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.Order.Remove;

public record RemoveOrderCommand(int Id) : IRequest<Response>;