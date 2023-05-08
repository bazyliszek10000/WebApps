using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace MbWebApp.Infrastructures;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);
        List<ValidationFailure> errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => new ValidationFailure(x.PropertyName, x.ErrorMessage))
            .ToList();
        
        if (errorsDictionary.Any())
        {
            throw new ValidationException(errorsDictionary);
        }
        return await next();
    }
}