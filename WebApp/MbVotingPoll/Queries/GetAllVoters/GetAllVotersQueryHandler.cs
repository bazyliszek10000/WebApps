using MbDB.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbVotingPoll.Queries.GetAllVoters;

public class GetAllVotersQueryHandler : IRequestHandler<GetAllVotersQuery, List<Voter>>
{
    public GetAllVotersQueryHandler()
    {
    }

    public async Task<List<Voter>> Handle(GetAllVotersQuery getAllVotersQuery, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            return await mbDbContext.Voters.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}