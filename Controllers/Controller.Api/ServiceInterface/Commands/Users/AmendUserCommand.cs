using Controller.Api.ServiceInterface.Contracts;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Controller.Api.ServiceInterface.Commands.Users;

public record AmendUserCommand(int id, JsonPatchDocument<User> Amendment) : IRequest<User>;