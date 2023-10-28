using Bookreader.Domain.Enums;

namespace Bookreader.Domain.Entities;

public class User : Human
{
    public string PhoneNumber { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string Bio { get; set; } = String.Empty;
    
    public bool IsDeleted { get; set; } = false;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public string Salt { get; set; } = string.Empty;
    
    public bool PhoneNumberConfirmed { get; set; }
    
    public IdentityRole IdentityRole { get; set; }
}