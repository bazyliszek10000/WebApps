using MediatR;

namespace MbStore.Commands.RemoveOrder;

public class RemoveOrderCommand : IRequest<Unit>
{
    public int Id { get; set; }
}