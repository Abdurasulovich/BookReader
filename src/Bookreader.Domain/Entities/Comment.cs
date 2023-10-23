namespace Bookreader.Domain.Entities;

public class Comment : Auditable
{
    public long UserId { get; set; }
    
    public long BookId { get; set; }

    public string Definition { get; set; } = String.Empty;
}