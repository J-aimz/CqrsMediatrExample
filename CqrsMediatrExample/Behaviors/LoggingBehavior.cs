using MediatR;

namespace CqrsMediatrExample.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //props
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        //ctor
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            var response = await next();

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;

        }
        
        
    }
}
