using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitoGraph.Api.Behaviors
{
    public class EventLoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<EventLoggerBehavior<TRequest, TResponse>> _logger;
        public EventLoggerBehavior(ILogger<EventLoggerBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = await next();

            var data = new Dictionary<string, object>
            {
                {
                    "request", request
                },
                {
                    "response", response
                }
            };

            _logger.LogInformation(data.ToJsonString());

            return response;
        }
    }
}