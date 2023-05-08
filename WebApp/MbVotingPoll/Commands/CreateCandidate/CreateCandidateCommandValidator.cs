using FluentValidation;
using MbVotingPoll.Commands.CreateVoter;

namespace MbVotingPoll.Commands.CreateCandidate;

public sealed class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
{
    public CreateCandidateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}