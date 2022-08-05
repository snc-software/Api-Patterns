using ApiPatterns.Core.Domain;
using Bogus;

namespace ApiPatterns.Core.Persistence.Fakers;

public abstract class FakerBase<TModel> : Faker<TModel> where TModel : ModelBase
{
    protected FakerBase(Random random)
    {
        Randomizer.Seed = random;
    }
}