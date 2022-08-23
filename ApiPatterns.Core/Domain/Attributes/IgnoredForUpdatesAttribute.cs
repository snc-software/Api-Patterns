namespace ApiPatterns.Core.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class IgnoredForUpdatesAttribute : Attribute
{
}