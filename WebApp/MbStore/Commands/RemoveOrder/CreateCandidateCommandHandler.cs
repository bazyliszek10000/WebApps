using MbDB.Entities;
using MediatR;

namespace MbStore.Commands.RemoveOrder;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, Unit>
{
    public RemoveOrderCommandHandler()
    {
    }

    public async Task<Unit> Handle(RemoveOrderCommand removeOrderCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            Order removeOrder = new Order { Id = removeOrderCommand.Id };
            mbDbContext.Orders.Attach(removeOrder);
            mbDbContext.Orders.Remove(removeOrder);
            await mbDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}