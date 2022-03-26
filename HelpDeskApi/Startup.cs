using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDeskApi.Entities;
using HelpDeskApi.Services;
using HelpDeskApi.Middleware;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using HelpDeskApi.Models;
using HelpDeskApi.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using HelpDeskApi.Authorization;

namespace HelpDeskApi
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

            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication")
                .Bind(authenticationSettings);



            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };

            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("3Month", builder => builder.AddRequirements(new MinimumTimeWork(3) ));
            });


            services.AddScoped<IAuthorizationHandler, MinimumTimeWorkHandler>();
            services.AddControllers().AddFluentValidation();
            services.AddDbContext<HelpDeskDbContext>();
            services.AddScoped<HelpDeskSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IProblemPlaceService, ProblemPlaceService>();
            services.AddScoped<IAcountService, AcountService>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IValidator<ClientQuery>, ClientQueyValidator>();
            services.AddScoped<RequestTimeMiddleware>();
            services.AddSwaggerGen();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HelpDeskSeeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpDeskApi");
            });

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
