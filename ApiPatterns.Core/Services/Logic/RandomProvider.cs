using ApiPatterns.Core.Services.Logic.Interfaces;

namespace ApiPatterns.Core.Services.Logic;

public class RandomProvider : IRandomProvider
{
    public Random Get()
    {
        var seed = $"{Environment.MachineName}_{DateTime.UtcNow.Date}";
        return new Random(seed.ToCharArray().Sum(c => c));

    }
}