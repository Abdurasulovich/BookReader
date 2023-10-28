namespace Bookreader.Domain.Exceptions.Book;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException()
    {
        TitleMessage = "Book not found";
    }
}