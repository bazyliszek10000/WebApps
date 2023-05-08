
using MbDB.Entities;

namespace MbStore.Queries.GetOrders;

public class GridDataDto
{
    public GridDataDto()
    {
        Orders = new List<Order>();
    }
    
    public List<Order> Orders { get; set; }
    
    public int TotalCount { get; set; }
    
    public int NumberOfPages { get; set; }
}