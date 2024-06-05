using MediatR;

namespace TomasosPizzeria.UseCases.Category.Create;

public record CreateCategoryCommand(string Name) : IRequest;