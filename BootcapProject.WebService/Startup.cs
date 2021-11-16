using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BootcapProject.WebService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //var logger = services.RegisterLogger();
            //logger.Info("Web application, start configuration");

            //services.RegisterInfrastructure();

            //services.RegisterKeyVault();

            //services.RegisterHealthCheck();

            //services.RegisterHttpChannel();

            //services.RegisterServices();

            //services.AddScoped<RequestValidationMiddleware>();
            //services.AddScoped<AuthenticationMiddleware>();
            //services.AddScoped<SecurityMiddleware>();

            //services.AddSingleton<IAuthenticationKeys>(new DefaultAuthenticationKeys(string.Empty, string.Empty));
            //services.AddSingleton<ISecurityKeys>(new DefaultSecurityKeys(string.Empty));

            //services.AddScoped<IAuthenticatedMessaging, AuthenticatedMessaging>();
            //services.AddScoped<ISecuredMessaging, SecuredMessaging>();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo() { }); });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Web Service");
                c.RoutePrefix = String.Empty;
            });

            //app.UseExceptionMiddleware();

            //app.UseRequestValidationMiddleware();

            //if (env.IsStaging() || env.IsProduction())
            //{
            //    app.UseAuthenticationMiddleware();
            //    app.UseSecurityMiddleware();
            //}

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
