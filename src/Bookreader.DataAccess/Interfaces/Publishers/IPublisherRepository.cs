using Bookreader.DataAccess.Common.Interfaces;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;

namespace Bookreader.DataAccess.Interfaces.Publishers;

public interface IPublisherRepository : IRepository<Publisher, Publisher>,
    IGetAll<PublisherViweModel>
{
    
}