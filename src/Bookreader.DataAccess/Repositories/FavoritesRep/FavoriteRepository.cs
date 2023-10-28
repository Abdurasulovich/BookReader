using Bookreader.DataAccess.Interfaces.Favorites;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.FavoritesRep;

public class FavoriteRepository : BaseRepository, IFavoriteRepository
{
    public async Task<int> CreateAsync(Favorite entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "favorites(user_id, book_id, created_at, updated_at) " +
                        "VALUES (@UserId, @BookId, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long Id, Favorite entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "DELETE FROM favorites WHERE id=@id;";
            var result = await _connection.ExecuteAsync(query, new { id = Id });
            return result;
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Favorite?> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT COUNT(*) FROM favorites;";
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

    public async Task<IList<Favorite>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM favorites " +
                        $"OFFSET {@params.GetSkipCount()} limit {@params.PageSize};";
            var result = (await _connection.QueryAsync<Favorite>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Favorite>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}