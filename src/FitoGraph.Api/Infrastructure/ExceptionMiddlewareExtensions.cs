using System.Net;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FitoGraph.Api.Infrastructure
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        ResultWrapper<ErrorOutput> errorBody = new ResultWrapper<ErrorOutput>()
                        {
                            Status = false,
                            Message = "Internal Server Error.",
                            Result = new ErrorOutput()
                            {
                                TechnicalMessage = $"Code: {context.Response.StatusCode}, Err: {contextFeature.Error.Message}"
                            }
                        };
                        await context.Response.WriteAsync(errorBody.ToJsonString());
                    }
                });
            });
        }
    }
}