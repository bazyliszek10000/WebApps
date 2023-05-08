using FluentValidation;
using FluentValidation.Results;

namespace MbVotingPoll.Commands.Vote;

public sealed class VoteCommandValidator : AbstractValidator<VoteCommand>
{
    public VoteCommandValidator()
    {
        RuleFor(x => x.CandidateId).NotEmpty();
        RuleFor(x => x.VoterId).NotEmpty();
    }
}