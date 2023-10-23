namespace Bookreader.Domain.Entities;

public class Basket : Auditable
{
    public long BookId { get; set; }
    
    public long UserId { get; set; }

    public long CountOfBooks { get; set; }
}