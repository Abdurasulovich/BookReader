using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Baskets;

public interface IBasketRepository : IRepository<Basket, Basket>, 
    IGetAll<Basket>
{
    
}