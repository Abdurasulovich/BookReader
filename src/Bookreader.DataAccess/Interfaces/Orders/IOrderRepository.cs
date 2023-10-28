using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, OrderViewModel>,
    IGetAll<OrderViewModel>
{
    
}