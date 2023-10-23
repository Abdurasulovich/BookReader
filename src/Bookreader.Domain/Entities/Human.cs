namespace Bookreader.Domain.Entities;

public abstract class Human : Auditable
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;
}