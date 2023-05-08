using MbDB.Entities;
using MbVotingPoll.Queries.GetAllVoters;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbVotingPoll.Queries.GetAllCandidates;

public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, List<Candidate>>
{
    public GetAllCandidatesQueryHandler()
    {
    }

    public async Task<List<Candidate>> Handle(GetAllCandidatesQuery getAllCandidatesQuery, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            return await mbDbContext.Candidates.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}