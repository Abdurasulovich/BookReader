using Bookreader.DataAccess.Interfaces.Authors;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.Authors;

public class AuthorRepository : BaseRepository, IAuthorRepository
{
    public async Task<int> CreateAsync(Author entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "author(first_name, last_name, created_at, updated_at) " +
                        "VALUES (@FirstName, @LastName, @CreatedAt, @UpdatedAt);";
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

    public async Task<int> UpdateAsync(long Id, Author entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE author " +
                        "SET first_name=@FirstName, last_name=@LastName, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                        $"WHERE id = {Id}";
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

    public Task<int> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<Author?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM author WHERE id = @id;";
            var result = await _connection.QuerySingleAsync<Author>(query, new {id=Id});
            return result;
        }
        catch
        {
            return new Author();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }
}