using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Travel.Application.Common.Exceptions.ValidationException;

namespace Travel.Application.Common.Behaviors
{
  public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
  {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
      _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      if (!_validators.Any()) return await next();

      var context = new ValidationContext<TRequest>(request);
      var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
      var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

      if (failures.Count != 0)
        throw new ValidationException(failures);

      return await next();
    }
  }
}