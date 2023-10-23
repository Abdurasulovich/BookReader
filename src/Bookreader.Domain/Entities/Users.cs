namespace Bookreader.Domain.Entities;

public class Users : Human
{
    public string PhoneNumber { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string Bio { get; set; } = String.Empty;
}