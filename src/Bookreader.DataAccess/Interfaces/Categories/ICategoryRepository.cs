using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, 
    IGetAll<Category>
{
    
}