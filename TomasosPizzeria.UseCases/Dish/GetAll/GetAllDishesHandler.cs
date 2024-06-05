using MediatR;
using TomasosPizzeria.UseCases.Interfaces.Repository;

namespace TomasosPizzeria.UseCases.Dish.GetAll;

public class GetAllDishesHandler(IDishRepo dishRepo) : IRequestHandler<GetAllDishesQuery, IEnumerable<Domain.Entities.Dish>>
{
    public async Task<IEnumerable<Domain.Entities.Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        return await dishRepo.GetAllDishes();
    }
}