using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FitoGraph.Api.Helpers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FitoGraph.Api.Helpers.Settings;

namespace FitoGraph.Api.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly AppSettings _appSettings;
        public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            string requestName = request.ToString();
            if (!requestName.EndsWith("Command"))
            {
                return await next();
            }

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled))
            {
                TResponse response = await next();

                transaction.Complete();

                return response;
            }

        }
    }
}