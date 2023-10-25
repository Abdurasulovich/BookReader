namespace Bookreader.Domain.Entities;

public class Favorite : Auditable
{
    public long UserId { get; set; }
    
    public long BookId { get; set; }
}