using Controller.Api.ServiceInterface.Contracts;
using MediatR;

namespace Controller.Api.ServiceInterface.Queries.Users;

public record GetUserQuery(int id) : IRequest<User>;