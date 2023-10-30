using Bookreader.DataAccess.Utils;
using Bookreader.Domain.Entities;
using Bookreader.Service.Dtos.Author;
using Bookreader.Service.Dtos.Category;

namespace Bookreader.Service.Interfaces.Author;

public interface IAuthorService
{
    public Task<bool> CreateAsync(AuthorCreateDto dto);

    public Task<bool> UpdateAsync(long authorId, AuthUpdateDto dto);

    public Task<bool> DeleteAsync(long authorId);

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);
    
    public Task<Category> GetByIdAsync(long authorId);
}