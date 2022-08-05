using ApiPatterns.Core.Services.Data.Users.Interfaces;
using Controller.Api.ServiceInterface.Contracts;
using Controller.Api.ServiceInterface.Queries.Users;
using Controller.Api.ServiceModel.Mappings.Interfaces;
using MediatR;

namespace Controller.Api.ServiceModel.Queries.Users;

public class GetUserQueryHandler : RequestHandler<GetUserQuery, User>
{
    readonly IUserRetriever _retriever;
    readonly IUserMapper _mapper;
    
    public GetUserQueryHandler(IUserMapper mapper, IUserRetriever retriever)
    {
        _mapper = mapper;
        _retriever = retriever;
    }
    
    protected override User Handle(GetUserQuery request)
    {
        var user = _retriever.GetByKey(request.id);

        return _mapper.Map(user);
    }
}