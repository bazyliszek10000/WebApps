using MbDB.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbStore.Queries.GetOrders;

public class GetAllCandidatesQueryHandler : IRequestHandler<GetOrdersQuery, GridDataDto>
{
    public GetAllCandidatesQueryHandler()
    {
    }

    public async Task<GridDataDto> Handle(GetOrdersQuery getOrdersQuery, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            int skip = (getOrdersQuery.PageNumber - 1) * getOrdersQuery.PageNumber;
            IQueryable<Order> query = mbDbContext.Orders.AsQueryable();
            if (getOrdersQuery.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreateDate >= getOrdersQuery.DateFrom.Value);
            }
            if (getOrdersQuery.DateTo.HasValue)
            {
                query = query.Where(x => x.CreateDate <= getOrdersQuery.DateTo.Value);
            }
            if (getOrdersQuery.Status.HasValue)
            {
                query = query.Where(x => x.Status == getOrdersQuery.Status.Value);
            }
            
            List<Order> orders = await query.Skip(skip).Take(getOrdersQuery.NumberOfRecords + 1).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            int totalCount = orders.Count;
            if (totalCount > getOrdersQuery.NumberOfRecords)
            {
                orders.RemoveAt(getOrdersQuery.NumberOfRecords);
                totalCount = await mbDbContext.Orders.CountAsync(cancellationToken: cancellationToken);
            }

            return new GridDataDto
            {
                Orders = orders,
                TotalCount = totalCount,
                NumberOfPages = (int)Math.Ceiling((double)totalCount/getOrdersQuery.NumberOfRecords)
            };
        }
    }
}