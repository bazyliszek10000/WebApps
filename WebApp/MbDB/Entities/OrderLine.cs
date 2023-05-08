namespace MbDB.Entities;

public class OrderLine
{
    public OrderLine()
    {
        Orders = new List<Order>();
    }
    
    public int Id { get; set; }
    
    public string Product { get; set; }
    
    public decimal Price { get; set; }
    
    public virtual List<Order> Orders { get; set; }
}