using MbDB.Entities;
using MediatR;

namespace MbStore.Queries.GetOrders;

public class GetOrdersQuery : IRequest<GridDataDto>
{
    public DateTime? DateFrom { get; set; }
    
    public DateTime? DateTo { get; set; }

    public OrderStatus? Status { get; set; }

    public int PageNumber { get; set; }
    
    public int NumberOfRecords { get; set; }
}