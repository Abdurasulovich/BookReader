using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Publishers;

public interface IPublisherRepository : IRepository<Publisher, Publisher>,
    IGetAll<Publisher>
{
    
}