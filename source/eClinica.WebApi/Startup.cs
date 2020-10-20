using eClinica.Core.Configuration;
using eClinica.Core.Extensions;
using eClinica.Infrastructure.Data;
using eClinica.Infrastructure.Extensions;
using eClinica.Infrastructure.Util;
using eClinica.WebApi.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;

namespace eClinica.WebApi
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
            services.AddApplicationInsightsTelemetry();

            var applicationOptions = new ApplicationOptions();
            Configuration.GetSection(ApplicationOptions.Section).Bind(applicationOptions);
            services.AddSingleton(applicationOptions);

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"),
                SqlOptions =>
                { SqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                }
             ));

            services.AddCors();
            services.AddMapperService();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddCoreScopedServices();
            services.AddInfrastructureServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eClinica WEBAPI", Version = "v1" });
            });

            ValidatorOptions.LanguageManager.Culture = new CultureInfo("es");
            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eClinica WEBAPI V1");
            });

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseMiddleware<EFExceptionsMiddleware>();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
