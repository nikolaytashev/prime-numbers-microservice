using Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PrimeNumbersMicroservice.Common;
using Services.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace PrimeNumbersMicroservice
{
    /// <summary>
    /// Web API's Startup class
    /// </summary>
    public class Startup
    {
        /// <summary> Constructs the Startup </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary> Configuration object </summary>
        public IConfiguration Configuration { get; }

        /// <summary> Configures the Web API Services </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediator();
            services.AddValidators();
            services.AddMemoryCache();
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
            services.AddServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prime Numbers Microservice API",
                    Description = "A Web API for prime numbers validation and generation.",
                    Contact = new OpenApiContact
                    {
                        Name = "Nikolay Tashev",
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary> Configures the Web API </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prime Numbers Microservice API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
