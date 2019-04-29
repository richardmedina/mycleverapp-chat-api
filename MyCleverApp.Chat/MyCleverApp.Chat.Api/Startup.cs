using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyCleverApp.Chat.Api.MapperProfiles;
using MyCleverApp.Chat.Model;
using MyCleverApp.Chat.Services;
using MyCleverApp.Chat.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace MyCleverApp.Chat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();

            ConfigureDatabase(services);
            ConfigureAuthentication(services);
            ConfigureBusinessServices(services);
            ConfigureApiDoc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ChatDbSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCleverAppChatApi");
                //c.RoutePrefix = "/api/docs";
            });

            app.UseMvc();

            SeedDatabase(seeder);
        }

        private void ConfigureDatabase (IServiceCollection services)
        {
            services.AddDbContext<ChatDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MyCleverAppChatDb")));
            services.AddTransient<ChatDbSeeder>();
        }

        private void SeedDatabase (ChatDbSeeder seeder)
        {
            seeder.Ensure().Wait();
        }

        private void ConfigureBusinessServices (IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IContactListService, ContactListService>();
            services.AddTransient<IUserService, UserService>();
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Authentication").GetValue<string>("Secret"));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt => {
                opt.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var ctx = context;
                        return Task.CompletedTask;
                    }
                };
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private void ConfigureApiDoc (IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MyCleverAppChatApi", Version = "v1" });
                //c.AddSecurityDefinition("oauth2", new ApiKeyScheme
                //{
                //    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                //    In = "header",
                //    Name = "Authorization",
                //    Type = "apiKey"
                //});
            });
        }
    }
}
