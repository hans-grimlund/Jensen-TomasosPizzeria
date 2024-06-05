using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.Order.ChangeStatus;

public record ChangeOrderStatusCommand(int Id, string Status) : IRequest<Response>;