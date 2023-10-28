namespace Bookreader.Domain.Exceptions.Category;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException()
    {
        this.TitleMessage = "Category not found!";
    }
}