using System;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using FitoGraph.Api.Infrastructure;

namespace FitoGraph.Api.Handler
{
    public class CustomerRegisterEventHandler : INotificationHandler<CustomerLoggedInEvent>
    {
        private readonly ILogger<CustomerRegisterEventHandler> _logger;

        public CustomerRegisterEventHandler(ILogger<CustomerRegisterEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerLoggedInEvent notification, CancellationToken cancellationToken)
        {
            string logMessage = $"new registration at {DateTime.Now}: \r\n {notification.ToJsonString()}";
            _logger.Log(LogLevel.Information, logMessage);
            return Task.FromResult(0);
        }
    }
}