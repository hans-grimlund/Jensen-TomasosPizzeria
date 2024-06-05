using MediatR;
using SharedKernel;

namespace TomasosPizzeria.UseCases.Dish.Update;

public record UpdateDishCommand(int Id, string? Name, string? Description, 
    decimal Price, int CategoryId, IEnumerable<int> Ingredients) : IRequest<Response>;