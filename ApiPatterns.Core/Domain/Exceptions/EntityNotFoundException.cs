namespace ApiPatterns.Core.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName)
    {
        EntityName = entityName;
    }
    
    public string EntityName { get; }
    public override string Message => $"The {EntityName} was not found.";
}