using ApiPatterns.Core.Domain;
using Controller.Api.ServiceInterface.Contracts;
using Controller.Api.ServiceModel.Mappings.Interfaces;
using HashidsNet;

namespace Controller.Api.ServiceModel.Mappings;

public class UserMapper : IUserMapper
{
    readonly IHashids _hashids;

    public UserMapper(IHashids hashids)
    {
        _hashids = hashids;
    }

    public User Map(UserModel model)
    {
        return new User(_hashids.Encode(model.Id), model.FirstName, model.Surname);
    }

    public UserModel Map(User model)
    {
        return new UserModel
        {
            Id = _hashids.DecodeSingle(model.Id),
            FirstName = model.FirstName,
            Surname = model.Surname
        };
    }
}