using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using RDIChallenge.API.DependencyGroups;
using System.IO;
using FluentValidation.AspNetCore;
using RDIChallenge.Respository.Database.Context;
using Microsoft.EntityFrameworkCore;
using RDIChallenge.Domain.Interfaces.Services;
using RDIChallenge.Respository.Database.Transacions;
using RDIChallenge.API.Middleware;

namespace RDIChallenge.API
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddMvc()
            .AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .AddFluentValidation(config =>
                config.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<RDIChallengeContext>(opt =>
                opt.UseInMemoryDatabase("RDIChallengeDatabase")
            );

            services.AddScoped<RDIChallengeContext, RDIChallengeContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            ApplicationServiceDependencies.ConfigureServices(services);

            services.AddMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RDI Challenge API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
