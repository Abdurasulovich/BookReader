namespace Bookreader.Domain.Exceptions.Order;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException()
    {
        TitleMessage = "Order not found";
    }
}