namespace Bookreader.DataAccess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);

    public Task<int> UpdateAsync(long Id, TEntity entity);

    public Task<int> DeleteAsync(long Id);

    public Task<TViewModel?> GetByIdAsync(long Id);

    public Task<long> CountAsync();
}