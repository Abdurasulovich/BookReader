using System.Collections;
using Bookreader.DataAccess.Utils;

namespace Bookreader.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search, PaginationParams @params);
}