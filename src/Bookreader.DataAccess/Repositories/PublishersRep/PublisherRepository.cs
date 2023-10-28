using Bookreader.DataAccess.Interfaces.Publishers;
using Bookreader.DataAccess.Utils;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.PublishersRep;

public class PublisherRepository : BaseRepository, IPublisherRepository
{
    public async Task<int> CreateAsync(Publisher entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "publisher(name, created_at, updated_at) " +
                        "VALUES(@Name, @CreatedAt, @UpdatedAt);";
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

    public async Task<int> UpdateAsync(long Id, Publisher entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE " +
                        "publisher SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt) " +
                        $"WHERE id ={Id}";
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

    public Task<Publisher?> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT COUNT(*) FROM publisher;";
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

    public async Task<IList<PublisherViweModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM publisher " +
                        $"OFFSET {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<PublisherViweModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<PublisherViweModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}