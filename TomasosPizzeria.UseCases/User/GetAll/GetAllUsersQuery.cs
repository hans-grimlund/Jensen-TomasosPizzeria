using MediatR;
using TomasosPizzeria.UseCases.User.GetProfile;

namespace TomasosPizzeria.UseCases.User.GetAll;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;