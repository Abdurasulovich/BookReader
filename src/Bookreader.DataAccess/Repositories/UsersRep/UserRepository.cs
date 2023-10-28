using System.Runtime.InteropServices.ComTypes;
using Bookreader.DataAccess.Interfaces.Users;
using Bookreader.DataAccess.Utils;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.UsersRep;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "users(first_name, last_name, phone_number, email, image_path, bio, created_at, updated_at, Is_deleted, Password, Salt, Phone_number_confirmed, Identity_role) " +
                        "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @ImagePath, @Bio, @CreatedAt, @UpdatedAt, @IsDeleted, @Password, @Salt, @PhoneNumberConfirmed, @PhoneNumberConfirmed, @IdentityRole);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long Id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE users " +
                        "SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, email=@Email, image_path=@ImagePath, bio= @Bio, created_at=@CreatedAt, updated_at=@UpdatedAt, Is_deleted=@IsDeleted, " +
                        "Password=@Password, Salt=@Salt, Phone_number_confirmed=@PhoneNumberConfirmed, Identity_role=@IdentityRole " +
                        $"WHERE id = {Id};";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }finally
        {
            await _connection.CloseAsync();
        }
    }

    public  Task<int> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserViewModel?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM users " +
                        "WHERE id =@id;";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { id = Id });
            return result;
        }
        catch
        {
            return new UserViewModel();
        }
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT COUNT(*) FROM users;";
            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM users " +
                        $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = $"SELECT * FROM users WHERE first_name ILIKE '%{search}%' " +
                        $"OR last_name ILIKE '%{search}%' " +
                        $"OR phone_number ILIKE '%{search}%' " +
                        $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();
            return (ItemsCount: result.Count, result);
        }
        catch
        {
            return (ItemsCount: 0, new List<UserViewModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM users WHERE phone_number = @PhoneNumber;";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

}