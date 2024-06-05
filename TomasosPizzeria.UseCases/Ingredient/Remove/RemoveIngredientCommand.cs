using MediatR;

namespace TomasosPizzeria.UseCases.Ingredient.Remove;

public record RemoveIngredientCommand(int Id) : IRequest;