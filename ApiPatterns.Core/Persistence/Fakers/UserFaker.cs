using ApiPatterns.Core.Domain;
using Bogus;

namespace ApiPatterns.Core.Persistence.Fakers;

public sealed class UserFaker : FakerBase<UserModel>
{
    public UserFaker(Random random) : base(random)
    {
        RuleFor(p => p.Id, v => v.IndexFaker);
        RuleFor(p => p.UniqueId, _ => Guid.NewGuid());
        RuleFor(p => p.FirstName, v => v.Person.FirstName);
        RuleFor(p => p.Surname, v => v.Person.LastName);
    }
}