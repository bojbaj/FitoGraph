using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Firebase.Authentication.Extensions;
using AutoMapper;
using FitoGraph.Api.Behaviors;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FitoGraph.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var AppSettingsSection = Configuration.GetSection("App");
            string fireBaseProjectId = Configuration.GetValue<string>("App:FireBase:ProjectId");

            bool useProxy = Configuration.GetValue<bool>("App:Proxy:Enable");
            var webProxy = new WebProxy();
            if (useProxy)
            {
                string proxyHost = Configuration.GetValue<string>("App:Proxy:Server");
                int proxyPort = Configuration.GetValue<int>("App:Proxy:Port");
                string proxyUserName = Configuration.GetValue<string>("App:Proxy:Username");
                string proxyPassword = Configuration.GetValue<string>("App:Proxy:Password");
                bool hasAuth = !string.IsNullOrEmpty(proxyUserName);
                webProxy = new WebProxy
                {
                    Address = new Uri($"http://{proxyHost}:{proxyPort}"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = !hasAuth,
                };
                if (hasAuth)
                {
                    webProxy.Credentials = new NetworkCredential(userName: proxyUserName, password: proxyPassword);
                }
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.BackchannelHttpHandler = new HttpClientHandler
                    {
                        Proxy = webProxy
                    };
                    options.Authority = $"https://securetoken.google.com/{fireBaseProjectId}";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"https://securetoken.google.com/{fireBaseProjectId}",
                        ValidateAudience = true,
                        ValidAudience = fireBaseProjectId,
                        ValidateLifetime = true
                    };
                });

            services.AddControllers();

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.Configure<AppSettings>(AppSettingsSection);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));

            services.AddScoped<IFireBaseTool, FireBaseTool>();

            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowCredentials()
                        );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("ApiCorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
