namespace Bookreader.Domain.Entities;

public class Favorites : Auditable
{
    public long UserId { get; set; }
    
    public long BookId { get; set; }
}