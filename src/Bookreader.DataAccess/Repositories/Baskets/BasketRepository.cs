using Bookreader.DataAccess.Interfaces.Baskets;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.Baskets;

public class BasketRepository : BaseRepository, IBasketRepository
{
    public async Task<int> CreateAsync(Basket entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO " +
                           "basket(book_id, user_id, count_of_books, created_at, updated_at) " +
                           "VALUES (@BookId, @UserId, @CountOfBooks, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long Id, Basket entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE basket " +
                           "SET book_id=@BookId, user_id=@UserId, count_of_books=@CountOfBooks, created_at=CreatedAt, updated_at=@UpdatedAt " +
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM basket " +
                           $"WHERE id=@id ;";
            var result = await _connection.ExecuteAsync(query, new { id = id });
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

    public async Task<Basket?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM basket " +
                        "where id=@id";
            var result = await _connection.QuerySingleAsync<Basket>(query, new { id = id });
            return result;
        }
        catch
        {
            return new Basket();
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
            var query = "SELECT COUNT(*) FROM BASKET";
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

    public async Task<IList<Basket>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM basket ORDER BY id DESC " +
                        $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
            var result = (await _connection.QueryAsync<Basket>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Basket>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}