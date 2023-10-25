using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Comments;

public interface ICommentRepository : IRepository<Comment, Comment>,
    IGetAll<Comment>
{
    
}