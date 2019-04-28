using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyCleverApp.Chat.Api.MapperProfiles;
using MyCleverApp.Chat.Model;
using MyCleverApp.Chat.Services;
using MyCleverApp.Chat.Services.Interfaces;

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
            ConfigureBusinessServices(services);
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

            app.UseHttpsRedirection();
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
    }
}
