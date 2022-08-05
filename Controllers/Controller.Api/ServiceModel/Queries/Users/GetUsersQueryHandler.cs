using ApiPatterns.Core.Services.Data.Users.Interfaces;
using Controller.Api.ServiceInterface.Contracts;
using Controller.Api.ServiceInterface.Queries.Users;
using Controller.Api.ServiceModel.Mappings.Interfaces;
using MediatR;

namespace Controller.Api.ServiceModel.Queries.Users;

public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, List<User>>
{
    readonly IUserRetriever _retriever;
    readonly IUserMapper _mapper;

    public GetUsersQueryHandler(IUserRetriever retriever, IUserMapper mapper)
    {
        _retriever = retriever;
        _mapper = mapper;
    }
    
    protected override List<User> Handle(GetUsersQuery request)
    {
        var users = _retriever.Get();

        return users.Select(x => _mapper.Map(x)).ToList();
    }
}