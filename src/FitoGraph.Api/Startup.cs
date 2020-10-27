using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Firebase.Authentication.Extensions;
using AutoMapper;
using FitoGraph.Api.Behaviors;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public static IConfiguration StaticConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var AppSettingsSection = Configuration.GetSection("App");
            string fireBaseProjectId = Configuration.GetValue<string>("App:FireBase:ProjectId");

            AppSettingProxy proxySettings = Configuration.GetSection("App:Proxy").Get<AppSettingProxy>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.BackchannelHttpHandler = new HttpClientHandler
                    {
                        Proxy = Helpers.Lib.HttpClientManager.GetWebProxy(proxySettings)
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

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDb")));

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();                
            }

            app.ConfigureExceptionHandler(logger);

            DbInitializer.Initialize(dbContext);

            app.UseStaticFiles();

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
