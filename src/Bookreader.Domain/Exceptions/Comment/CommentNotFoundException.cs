using System.Runtime.CompilerServices;

namespace Bookreader.Domain.Exceptions.Comment;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException()
    {
        TitleMessage = "Comment not found";
    }
}