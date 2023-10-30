using Bookreader.Service.Dtos.Basket;

namespace Bookreader.Service.Interfaces.Basket;

public interface IBasketService
{
    public Task<bool> CreateAsync(BasketCreateDto dto);

    public Task<bool> UpdateAsync(long basketId, BasketUpdateDto dto);

    public Task<bool> DeleteAsync(long basketId);

    public Task<long> CountAsync();
    
    public Task<
}