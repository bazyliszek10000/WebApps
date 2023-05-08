using MbDB.Entities;
using MbVotingPoll.Commands.CreateVoter;
using MediatR;

namespace MbVotingPoll.Commands.CreateCandidate;

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
{
    public CreateCandidateCommandHandler()
    {
    }

    public async Task<int> Handle(CreateCandidateCommand createCandidateCommand, CancellationToken cancellationToken)
    {
        using (var mbDbContext = new MbDbContext())
        {
            Candidate candidate = new Candidate
            {
                Name = createCandidateCommand.Name
            };
            mbDbContext.Candidates.Add(candidate);
            await mbDbContext.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}