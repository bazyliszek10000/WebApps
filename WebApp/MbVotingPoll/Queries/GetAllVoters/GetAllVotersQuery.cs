using MediatR;

namespace MbVotingPoll.Queries.GetAllVoters;

public class GetAllVotersQuery : IRequest<List<Voter>>
{
}