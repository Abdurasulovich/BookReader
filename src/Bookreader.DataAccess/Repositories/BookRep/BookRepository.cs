using Bookreader.DataAccess.Interfaces;
using Bookreader.DataAccess.Interfaces.Books;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.BookRep;

public class BookRepository : BaseRepository, IBookRepository
{
    public async Task<int> CreateAsync(Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO books " +
                        "(name, description, price, image_path, category_id, publisher_id, isbn, writing_type_id, year, language_id, count_of_page, cover, created_at, updated_at, author_id) " +
                        "VALUES (@Name @Description, @Price, @ImagePath, @CategoryId, @PublisherId, @ISBN, @WritingTypeId, @Year, @LanguageId, @CountOfPage, @Cover, @CreatedAt, @UpdatedAt, @AuthorId);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long Id, Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE books " +
                        "SET name=@Name, description=@Description, price=@Price, image_path=@ImagePath, " +
                        "category_id=@CategoryId, publisher_id=@PublisherId, isbn=@ISBN, " +
                        "writing_type_id=@WritingTypeId, year=@Year, language_id=@LanguageId, " +
                        "count_of_page=@CountOfPage, cover=@Cover, created_at=@CreatedAt, updated_at=@UpdatedAt, author_id=@AuthorId " +
                        $"WHERE id={Id};";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "DELETE FROM books " +
                        "WHERE id=@id;";
            var result = await _connection.ExecuteAsync(query, new { id = Id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Book?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM books WHERE id=@id;";
            var result = await _connection.QuerySingleAsync<Book>(query, new { id = Id });
            return result;
        }
        catch
        {
            return new Book();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT count(*) FROM books";
            var result = await _connection.ExecuteAsync(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<(int ItemsCount, IList<Book>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = $"SELECT * FROM books INNER JOIN author on author.id=books.author_id " +
                        $"WHERE books.name ILIKE '%{search}' " +
                        $"OR author.first_name ILIKE '%{search}' " +
                        $"OR author.last_name ILIKE '%{search}' " +
                        $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Book>(query)).ToList();
            return (ItemsCount: result.Count, result);

        }
        catch
        {
            return (ItemsCount: 0, new List<Book>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Book>> GetAllByCategoryAsync(long categoryId, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM books INNER JOIN categories ON books.category_id = categories.id " +
                        $"OFFSET {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Book>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Book>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    /*public async Task<IList<Book>> GetAllByBookNameAsync(string bookName, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM books "
        }
        catch
        {

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }*/

    public async Task<IList<Book>> GetAllByAuthorIdAsync(string authorId, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM books INNER JOIN author ON books.author_id = author.id " +
                        $"OFFSET {@params.GetSkipCount()} limit  {@params.PageSize}";
            var result = (await _connection.QueryAsync<Book>(query)).ToList();
            return result;
        }
        catch (Exception e)
        {
            return new List<Book>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}