using ApiPatterns.Core.Domain;

namespace ApiPatterns.Core.Services.Data.Users.Interfaces;

public interface IUserRetriever
{
    List<UserModel> Get();
    UserModel GetByKey(int id);
}