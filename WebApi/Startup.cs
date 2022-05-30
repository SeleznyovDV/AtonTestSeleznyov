using Core;
using Core.Bl;
using Core.BL.Commands.CreateUserCommand;
using Core.Services.CurrentUserService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Wep.App.Middlewares;

namespace AtonTestSeleznyov
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _cfg = configuration;
        }

        public IConfiguration _cfg { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "AtonTestApi", Version = "v1" });
                x.OperationFilter<AddRequiredHeaderParameter>();
            });
            services.AddMediatR(typeof(CreateUserHandler).Assembly);
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(_cfg.GetConnectionString("Default"));
            });
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtonTest v1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
