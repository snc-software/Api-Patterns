using ApiPatterns.Core.Domain.Attributes;

namespace ApiPatterns.Core.Domain;

public class UserModel : ModelBase
{
    public string FirstName { get; set; }
    [IgnoredForUpdates]
    public string Surname { get; set; }
}