using Data;
using Data.CQRS.Commands.CreateUserCommand;
using Data.Services.AuthorizationService;
using Data.Services.CurrentUserService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "AtonTestApi", Version = "v1" });
            });
            services.AddMediatR(typeof(CreateUserHandler).Assembly);
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(_cfg.GetConnectionString("Default"));
            });
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            //services.AddAutoMapper(typeof(UserProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
