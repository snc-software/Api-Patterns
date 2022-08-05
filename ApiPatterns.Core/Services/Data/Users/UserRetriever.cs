using ApiPatterns.Core.Domain;
using ApiPatterns.Core.Domain.Exceptions;
using ApiPatterns.Core.Persistence.Fakers;
using ApiPatterns.Core.Services.Data.Users.Interfaces;
using ApiPatterns.Core.Services.Logic.Interfaces;

namespace ApiPatterns.Core.Services.Data.Users;

public class UserRetriever : IUserRetriever
{
    readonly IDictionary<int, UserModel> _usersIndexedById;
    readonly IRandomProvider _randomProvider;

    public UserRetriever(IRandomProvider randomProvider)
    {
        _randomProvider = randomProvider;
        var random = _randomProvider.Get();
        var faker = new UserFaker(random);
        var models = faker.Generate(random.Next(10, 50));
        _usersIndexedById = models.ToDictionary(x => x.Id, m => m);
    }
    
    public List<UserModel> Get()
    {
        return _usersIndexedById.Values.ToList();
    }

    public UserModel GetByKey(int id)
    {
        if (!_usersIndexedById.ContainsKey(id))
        {
            throw new EntityNotFoundException("User");
        }

        return _usersIndexedById[id];
    }
}