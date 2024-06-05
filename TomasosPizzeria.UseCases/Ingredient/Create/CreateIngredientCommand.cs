using MediatR;

namespace TomasosPizzeria.UseCases.Ingredient.Create;

public record CreateIngredientCommand(string Name) : IRequest;