using FluentValidation;
using MbStore.Commands.RemoveOrder;

namespace MbStore.Commands.EditOrder;

public sealed class CreateCandidateCommandValidator : AbstractValidator<EditOrderCommand>
{
    public CreateCandidateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ClientName).NotEmpty();
    }
}