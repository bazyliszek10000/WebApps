using MbDB.Entities;
using MbVotingPoll.Commands.CreateVoter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbVotingPoll.Commands.Vote;

public class VoteCommandHandler : IRequestHandler<VoteCommand, Unit>
{
    public VoteCommandHandler()
    {
    }

    public async Task<Unit> Handle(VoteCommand voteCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            Voter entity = await mbDbContext.Voters.SingleAsync(v => v.Id == voteCommand.VoterId);
            entity.CandidateId = voteCommand.CandidateId;
            await mbDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}