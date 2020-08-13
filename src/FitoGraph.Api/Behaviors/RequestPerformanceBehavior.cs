using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FitoGraph.Api.Behaviors
{
    public class RequestPerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<RequestPerformanceBehavior<TRequest, TResponse>> _logger;
        private readonly AppSettings _appSettings;
        public RequestPerformanceBehavior(ILogger<RequestPerformanceBehavior<TRequest, TResponse>> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;            
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_appSettings.Debug.MaxAllowedDelayForRequestsInMiliseconds == 0)
            {
                return await next();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TResponse response = await next();
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > _appSettings.Debug.MaxAllowedDelayForRequestsInMiliseconds)
            {
                _logger.LogWarning($"{request} has taken {stopwatch.ElapsedMilliseconds} ms to run completely !");
            }

            return response;

        }
    }
}