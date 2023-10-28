using Bookreader.Domain.Enums;

namespace Bookreader.Domain.Entities;

public class Order
{
    public long OrderNumber { get; set; }
    
    public long BookId { get; set; }
    
    public long UserId { get; set; }
    
    public Delivertype DeliverType { get; set; }

    public string Area { get; set; } = String.Empty;

    public string District { get; set; } = String.Empty;

    public string Address { get; set; } = String.Empty;
    
    public Paymenttype PaymentType { get; set; }
    
    public long PromoCode { get; set; }

    public string AdditionalComment { get; set; } = String.Empty;
    
    public float TotalPrice { get; set; }
    
    public int OrderCount { get; set; }
    
}