using MbDB.Entities;
using MediatR;

namespace MbStore.Commands.EditOrder;

public class EditOrderCommand : IRequest<Unit>
{
    public EditOrderCommand()
    {
        OrderLineIds = new List<int>();
    }

    public int Id { get; set; }

    public OrderStatus Status { get; set; }

    public string ClientName { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    public List<int> OrderLineIds { get; set; }
}