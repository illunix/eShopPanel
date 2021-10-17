using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace eShopPanel.Infrastructure.Behaviors
{
    public partial class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            var requestName = $"{typeof(TRequest).FullName}";

            var timer = Stopwatch.StartNew();

            _logger.LogInformation($"Handling {requestName}");

            var response = await next();

            timer.Stop();

            _logger.LogInformation($"Handled {requestName} in {timer.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
