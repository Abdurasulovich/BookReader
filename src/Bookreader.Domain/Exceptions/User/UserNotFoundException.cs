namespace Bookreader.Domain.Exceptions.User;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException()
    {
        TitleMessage = "User not found";
    }
}