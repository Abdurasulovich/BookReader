namespace Bookreader.Domain.Exceptions.Favorite;

public class FavoriteNotFoundException : NotFoundException
{
    public FavoriteNotFoundException()
    {
        TitleMessage = "Favotite not found";
    }
}