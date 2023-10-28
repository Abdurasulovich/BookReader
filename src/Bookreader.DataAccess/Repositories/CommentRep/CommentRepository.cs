using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using Bookreader.DataAccess.Interfaces.Comments;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.CommentRep;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public async Task<int> CreateAsync(Comment entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "comments(user_id, book_id, definition, created_at, updated_at) " +
                        "VALUES (@UserId, @BookId, @Definition, @CreatedAt, @UpdatedAt);";
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

    public Task<int> UpdateAsync(long Id, Comment entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT COUNT(*) FROM comments;";
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

    public async Task<IList<Comment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM comments;";
            var result = (await _connection.QueryAsync<Comment>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Comment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}