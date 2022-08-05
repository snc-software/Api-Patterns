using Controller.Api.ServiceInterface.Queries.Users;
using HashidsNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    readonly ILogger<UserController> _logger;
    readonly IMediator _mediator;
    readonly IHashids _hashids;

    public UserController(ILogger<UserController> logger, IMediator mediator, IHashids hashids)
    {
        _logger = logger;
        _mediator = mediator;
        _hashids = hashids;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _mediator.Send(new GetUsersQuery());

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var rawId = _hashids.Decode(id);
        if (rawId.Length == 0) return NotFound();

        var user = await _mediator.Send(new GetUserQuery(rawId[0]));

        return Ok(user);
    }
}