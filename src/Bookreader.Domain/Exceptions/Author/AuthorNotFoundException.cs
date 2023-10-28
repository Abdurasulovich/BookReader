namespace Bookreader.Domain.Exceptions.Author;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException()
    {
        TitleMessage = "Author not found";
    }
}