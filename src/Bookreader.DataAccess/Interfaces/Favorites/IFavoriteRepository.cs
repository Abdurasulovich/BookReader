using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Favorites;

public interface IFavoriteRepository : IRepository<Favorite, Favorite>,
    IGetAll<Favorite>
{
    
}