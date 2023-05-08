using MediatR;

namespace MbVotingPoll.Commands.CreateVoter;

public class CreateVoterCommand : IRequest<int>
{
    public string Name { get; }
    
    public CreateVoterCommand(string name)
    {
        Name = name;
    }
}