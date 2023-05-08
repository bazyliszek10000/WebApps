using MbDB.Entities;
using MediatR;

namespace MbStore.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    public CreateOrderCommandHandler()
    {
    }

    public async Task<int> Handle(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            List<OrderLine> orderLines = mbDbContext.OrderLines.Where(x => createOrderCommand.OrderLineIds.Contains(x.Id)).ToList();
            Order newOrder = Order.CreateOrder(
                createOrderCommand.ClientName,
                createOrderCommand.AdditionalInfo,
                orderLines);
            mbDbContext.Orders.Add(newOrder);
            await mbDbContext.SaveChangesAsync(cancellationToken);

            return newOrder.Id;
        }
    }
}