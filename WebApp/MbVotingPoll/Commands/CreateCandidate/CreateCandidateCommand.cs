using MediatR;

namespace MbVotingPoll.Commands.CreateCandidate;

public class CreateCandidateCommand : IRequest<int>
{
    public string Name { get; }
    
    public CreateCandidateCommand(string name)
    {
        Name = name;
    }
}