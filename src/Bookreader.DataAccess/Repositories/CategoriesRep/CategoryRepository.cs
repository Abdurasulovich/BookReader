﻿using Bookreader.DataAccess.Interfaces;
using Bookreader.DataAccess.Interfaces.Categories;
using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.CategoriesRep;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO categories(name, created_at, updated_at) " +
                        "VALUES (@Name, @CreatedAt, @UpdatedAt);";
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

    public async Task<int> UpdateAsync(long Id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE categories " +
                        "SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
            var query = "DELETE FROM categories " +
                        $"WHERE id=@id;";
            var result = await _connection.ExecuteAsync(query, new {id = Id});
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

    public async Task<Category?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM categories WHERE id =@id";
            var result = await _connection.QuerySingleAsync<Category>(query, new{id=Id});
            return result;

        }
        catch
        {
            return new Category();
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
            var query = "SELECT COUNT(*) FROM categories";
            var result = (long) await _connection.ExecuteAsync(query);
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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM categories " +
                        $"OFFSET {@params.GetSkipCount()} limit {@params.PageSize};";
            var result = (await _connection.QueryAsync<Category>(query)).ToList();
            return result;

        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}