using System.Reflection;

namespace ApiPatterns.Core.Domain.Extensions;

public static class PropertyInfoExtensions
{
    public static bool HasAttribute<TAttribute>(this PropertyInfo property)
        where TAttribute : Attribute
    {
        return property.GetCustomAttribute<TAttribute>() != null;
    }
}