using System;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using FitoGraph.Api.Infrastructure;

namespace FitoGraph.Api.Handler
{
    public class SendVerificationEmailEventHandler : INotificationHandler<SendVerificationEmailEvent>
    {
        private readonly ILogger<SendVerificationEmailEventHandler> _logger;

        public SendVerificationEmailEventHandler(ILogger<SendVerificationEmailEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SendVerificationEmailEvent notification, CancellationToken cancellationToken)
        {
            string logMessage = $"new confirmation email sent at {DateTime.Now}: \r\n {notification.ToJsonString()}";
            _logger.Log(LogLevel.Information, logMessage);
            return Task.FromResult(0);
        }
    }
}