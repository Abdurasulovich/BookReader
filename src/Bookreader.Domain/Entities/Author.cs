using System.Security.Cryptography.X509Certificates;

namespace Bookreader.Domain.Entities;

public class Author : Auditable
{
    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
}