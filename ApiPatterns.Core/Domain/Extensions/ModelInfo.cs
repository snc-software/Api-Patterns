using ApiPatterns.Core.Domain.Attributes;

namespace ApiPatterns.Core.Domain.Extensions;

public static class ModelInfo
{
    public static IEnumerable<string> NonUpdatableTableProps(Type modelType)
    {
        var nonPersistableProps = modelType.GetProperties().Where(x => x.HasAttribute<NotPersistedAttribute>());
        var notUpdatableProps =
            typeof(UserModel).GetProperties().Where(x => x.HasAttribute<IgnoredForUpdatesAttribute>());

        return nonPersistableProps.Concat(notUpdatableProps)
            .Select(x => x.Name.ToLower()).Distinct();
    }
}