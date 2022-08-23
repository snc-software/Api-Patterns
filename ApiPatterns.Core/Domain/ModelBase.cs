using ApiPatterns.Core.Domain.Attributes;

namespace ApiPatterns.Core.Domain;

public abstract class ModelBase
{
    [IgnoredForUpdates]
    public int Id { get; set; }
    [IgnoredForUpdates]
    public Guid UniqueId { get; set; }
}