using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Travel.Application.Common.Behaviors
{
  public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  {
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
      _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      try
      {
        return await next();
      }
      catch (Exception ex)
      {
        var requestName = typeof(TRequest).Name;
        _logger.LogError(ex, "Travel Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
        throw;
      }
    }
  }
}