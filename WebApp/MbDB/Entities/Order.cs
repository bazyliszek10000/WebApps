namespace MbDB.Entities;

public class Order
{
    public Order()
    {
        OrderLines = new List<OrderLine>();
    }
    
    public static Order CreateOrder(string clientName, string? additionalInfo, List<OrderLine> orderLines)
    {
        return new Order
        {
            CreateDate = DateTime.Now,
            Status = OrderStatus.New,
            ClientName = clientName,
            OrderPrice = orderLines.Sum(x => x.Price),
            OrderLines = orderLines,
            AdditionalInfo = additionalInfo
        };
    }
    
    public void EditNew(string clientName, string? additionalInfo, OrderStatus status, List<OrderLine> orderLines)
    {
        CanEditOnlyNewOrdersBusinessRule.Validation(this);

        Status = status;
        ClientName = clientName;
        OrderPrice = orderLines.Sum(x => x.Price);
        OrderLines = orderLines;
        AdditionalInfo = additionalInfo;
    }

    public int Id { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public string ClientName { get; set; }
    
    public decimal OrderPrice { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    // TODO mb: zmianieć na IReadOnluColection ...
    public virtual List<OrderLine> OrderLines { get; set; }
}