using ApiPatterns.Core.Domain;
using Controller.Api.ServiceInterface.Contracts;

namespace Controller.Api.ServiceModel.Mappings.Interfaces;

public interface IUserMapper
{
    User Map(UserModel model);
}