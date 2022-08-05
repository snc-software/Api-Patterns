using Controller.Api.ServiceInterface.Contracts;
using MediatR;

namespace Controller.Api.ServiceInterface.Queries.Users;

public record GetUsersQuery : IRequest<List<User>>;