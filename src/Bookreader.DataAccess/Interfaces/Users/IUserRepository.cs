using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
    public Task<User?> GetByIdCheckUser(long id);
}