using Bookreader.DataAccess.Interfaces.Orders;
using Bookreader.DataAccess.Utils;
using Bookreader.DataAccess.ViewModels;
using Bookreader.Domain.Entities;
using Dapper;

namespace Bookreader.DataAccess.Repositories.OrdersRep;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<int> CreateAsync(Order entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "INSERT INTO " +
                        "orders(order_number, book_id, user_id, delivery_type, area, district, address, payment_type, promocode, additional_comment, total_price, created_at, updated_at, order_count) " +
                        "VALUES (@OrderNumber, @BookId, @UserId, @DeliverType, @Area, @District, @Address, @PaymentType, @PromoCode, @AdditionalComment, @TotalPrice, @CreatedAt, @UpdatedAt, @OrderCount);";
            var resut = await _connection.ExecuteAsync(query, entity);
            return resut;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long Id, Order entity)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "UPDATE orders " +
                        "SET order_number=@OrderNumber, book_id=@BookId, user_id=@UserId, delivery_type=@DeliverType, " +
                        "area=@Area, district=@District, address=@Address, payment_type=@PaymentType, promocode=@PromoCode, " +
                        "additional_comment=@AdditionalComment, total_price=@TotalPrice, created_at=@CreatedAt, updated_at=@UpdatedAt, order_count = @OrderCount " +
                        $"WHERE id = {Id};";
            var resut = await _connection.ExecuteAsync(query, entity);
            return resut;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "DELETE FROM orders WHERE id = @id;";
            var resut = await _connection.ExecuteAsync(query, new {id=Id});
            return resut;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<OrderViewModel?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM orders WHERE id = @id";
            var result = await _connection.QuerySingleAsync<OrderViewModel>(query);
            return result;
        }
        catch
        {
            return new OrderViewModel();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT COUNT(*) FROM orders";
            var resut = (long) await _connection.ExecuteAsync(query);
            return resut;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<OrderViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var query = "SELECT * FROM orders " +
                        $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
            var resut = (await _connection.QueryAsync<OrderViewModel>(query)).ToList();
            return resut;
        }
        catch
        {
            return new List<OrderViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

}