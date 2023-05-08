using MediatR;

namespace MbVotingPoll.Commands.Vote;

public class VoteCommand : IRequest<Unit>
{
    public VoteCommand()
    {
    }
    
    public VoteCommand(int voterId, int candidateId)
    {
        VoterId = voterId;
        CandidateId = candidateId;
    }
    
    public int VoterId { get; set; }
    
    public int CandidateId { get; set; }
}