using MbDB.Entities;
using MediatR;

namespace MbVotingPoll.Commands.CreateVoter;

public class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand, int>
{
    public CreateVoterCommandHandler()
    {
    }

    public async Task<int> Handle(CreateVoterCommand createVoterCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            Voter voter = new Voter
            {
                Name = createVoterCommand.Name
            };
            mbDbContext.Voters.Add(voter);
            await mbDbContext.SaveChangesAsync(cancellationToken);

            return voter.Id;
        }
    }
}