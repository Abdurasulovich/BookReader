using System.Runtime.CompilerServices;
using Bookreader.Domain.Enums;

namespace Bookreader.Domain.Entities;

public class Book : Auditable
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;
    
    public float Price { get; set; }

    public string ImagePath { get; set; } = String.Empty;
    
    public long CategoryId { get; set; }
    
    public long PublisherId { get; set; }

    public string ISBN { get; set; } = String.Empty;
    
    public WritingtypeEnum WritingTypeId { get; set; }
    
    public DateTime Year { get; set; }
    
    public Languages LanguageId { get; set; }
    
    public long CountOfPage { get; set; }

    public string Cover { get; set; } = String.Empty;
    
    public long AuthorId { get; set; }
}