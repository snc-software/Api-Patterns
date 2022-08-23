namespace ApiPatterns.Core.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NotPersistedAttribute : Attribute
{
}