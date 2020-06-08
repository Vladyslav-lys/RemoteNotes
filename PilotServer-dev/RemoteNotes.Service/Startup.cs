using System;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RemoteNotes.Service.Hubs;

namespace RemoteNotes.Service
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
            #region Setup CORS

            var corsBuilder = new CorsPolicyBuilder();

            corsBuilder.WithOrigins("http://192.168.1.109:4200", "http://46.98.190.16:4200",
                "http://192.168.88.33:4200", "http://46.98.128.9:4200",
                "http://localhost:4200", "http://localhost:44362", "http://localhost:44342"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowCredentials();
            corsBuilder.AllowAnyMethod();

            services.AddCors(options => { options.AddPolicy("SiteCorsPolicy", corsBuilder.Build()); });

            #endregion

            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(10);
                hubOptions.ClientTimeoutInterval = TimeSpan.FromSeconds(110);
                hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(30);
            });

            DependencyConfiguration.Configure();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("SiteCorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<ServerHub>(string.Concat('/', ConfigurationManager.AppSettings["HubName"]),
                    options =>
                    {
                        options.Transports = HttpTransportType.WebSockets;
                        options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(10);
                        options.ApplicationMaxBufferSize = 5 * 1024 * 1024;
                        options.TransportMaxBufferSize = 5 * 1024 * 1024;
                    });
            });
        }
    }
}