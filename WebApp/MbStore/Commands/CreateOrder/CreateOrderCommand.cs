using MbDB.Entities;
using MediatR;

namespace MbStore.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public CreateOrderCommand()
    {
        OrderLineIds = new List<int>();
    }
    
    public string ClientName { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    public List<int> OrderLineIds { get; set; }
}