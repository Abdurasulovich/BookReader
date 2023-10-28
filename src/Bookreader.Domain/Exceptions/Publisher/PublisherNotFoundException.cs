namespace Bookreader.Domain.Exceptions.Publisher;

public class PublisherNotFoundException : NotFoundException
{
    public PublisherNotFoundException()
    {
        TitleMessage = "Publisher not found";
    }
}