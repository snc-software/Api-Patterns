using ApiPatterns.Core.Domain;
using ApiPatterns.Core.Domain.Attributes;
using ApiPatterns.Core.Domain.Extensions;
using ApiPatterns.Core.Services.Data.Users.Interfaces;
using Controller.Api.ServiceInterface.Commands.Users;
using Controller.Api.ServiceInterface.Contracts;
using Controller.Api.ServiceModel.Mappings.Interfaces;
using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Controller.Api.ServiceModel.Commands.Users;

public class AmendUserCommandHandler : RequestHandler<AmendUserCommand, User>
{
    readonly IUserRetriever _retriever;
    readonly IUserMapper _mapper;

    public AmendUserCommandHandler(IUserRetriever retriever, IUserMapper mapper)
    {
        _retriever = retriever;
        _mapper = mapper;
    }

    protected override User Handle(AmendUserCommand request)
    {
        var model = _retriever.GetByKey(request.id);
        var modelAsUser = _mapper.Map(model);
        var nonUpdatableProps = ModelInfo.NonUpdatableTableProps(typeof(UserModel));

        var operations = request.Amendment.Operations.Where(x => nonUpdatableProps.Contains(x.path.ToLower())).ToList();
        if (operations.Any())
        {
            var properties = operations.Select(x => x.path);
            throw new InvalidPatchPropertiesException(properties);
        }

        request.Amendment.ApplyTo(modelAsUser);
        // validate
        //send to db
        

        return modelAsUser;
    }
}