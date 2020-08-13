using System;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using FitoGraph.Api.Infrastructure;

namespace FitoGraph.Api.Handler
{
    public class CustomerLoggedInEventHandler : INotificationHandler<CustomerLoggedInEvent>
    {
        private readonly ILogger<CustomerLoggedInEventHandler> _logger;

        public CustomerLoggedInEventHandler(ILogger<CustomerLoggedInEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerLoggedInEvent notification, CancellationToken cancellationToken)
        {
            string logMessage = $"new login at {DateTime.Now}: \r\n {notification.ToJsonString()}";
            _logger.Log(LogLevel.Information, logMessage);            
            return Task.FromResult(0);
        }
    }
}