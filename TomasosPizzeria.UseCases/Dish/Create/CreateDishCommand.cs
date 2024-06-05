using MediatR;

namespace TomasosPizzeria.UseCases.Dish.Create;

public record CreateDishCommand(string Name, string Description, decimal Price, int Category, IEnumerable<int> Ingredients) : IRequest;