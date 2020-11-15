using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Travel.Application.Common.Behaviors
{
  public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
  {
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
      _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      var requestName = typeof(TRequest).Name;
      _logger.LogInformation("Travel Request: {@Request}",
       requestName, request);
    }
  }
}