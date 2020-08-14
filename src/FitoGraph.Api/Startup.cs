using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Behaviors;
using FitoGraph.Api.Helpers.Settings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddControllers();

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.Configure<AppSettings>(AppSettingsSection);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
