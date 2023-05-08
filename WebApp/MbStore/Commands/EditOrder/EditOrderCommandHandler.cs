using MbDB.Entities;
using MbStore.Commands.RemoveOrder;
using MediatR;

namespace MbStore.Commands.EditOrder;

public class CreateCandidateCommandHandler : IRequestHandler<EditOrderCommand, Unit>
{
    public CreateCandidateCommandHandler()
    {
    }

    public async Task<Unit> Handle(EditOrderCommand editOrderCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            Order order = mbDbContext.Orders.Single(x => x.Id == editOrderCommand.Id);
            List<OrderLine> orderLines = mbDbContext.OrderLines.Where(x => editOrderCommand.OrderLineIds.Contains(x.Id)).ToList();
            order.EditNew(editOrderCommand.ClientName,
                editOrderCommand.AdditionalInfo,
                editOrderCommand.Status,
                orderLines);
            await mbDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}