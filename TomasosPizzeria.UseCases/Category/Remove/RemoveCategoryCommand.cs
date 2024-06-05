using MediatR;

namespace TomasosPizzeria.UseCases.Category.Remove;

public record RemoveCategoryCommand(int CategoryId) : IRequest;