namespace ApiPatterns.Core.Domain;

public class UserModel : ModelBase
{
    public int Id { get; set; }
    public Guid UniqueId { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
}