using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Books;

public interface IBookRepository : IRepository<Book, Book>,
    ISearchable<Book>
{
    public Task<IList<Book>> GetAllByCategoryAsync(long categoryId, PaginationParams @params);

    public Task<IList<Book>> GetAllByBookNameAsync(string bookName, PaginationParams @params);

    public Task<IList<Book>> GetAllByAuthorIdAsync(string authorId, PaginationParams @params);
}