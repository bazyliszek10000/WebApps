using FluentValidation;
using MediatR;

namespace MbVotingPoll.Commands.CreateVoter;

public sealed class CreateVoterCommandValidator : AbstractValidator<CreateVoterCommand>
{
    public CreateVoterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}