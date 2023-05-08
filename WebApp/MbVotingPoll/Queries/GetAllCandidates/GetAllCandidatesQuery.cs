using MbDB.Entities;
using MediatR;

namespace MbVotingPoll.Queries.GetAllCandidates;

public class GetAllCandidatesQuery : IRequest<List<Candidate>>
{
}