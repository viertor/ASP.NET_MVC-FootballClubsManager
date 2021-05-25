using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballClubsManager
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
            services.AddControllersWithViews();

            services.AddDbContext<Infrastructure.Context.FootballClubsManagerContext>(options =>
            {
                options.UseInMemoryDatabase("footballclubs-in-memory-database");
            });
            
            services.AddScoped<Infrastructure.Context.FootballClubsManagerContext>();
            services.AddScoped<Infrastructure.Repositories.IFootbalClubsRepository, Infrastructure.Repositories.FootballClubsRepository>();
            services.AddScoped<Services.IFootballClubsService, Services.FootballClubsService>();
            services.AddScoped<Infrastructure.Repositories.IPlayersRepository, Infrastructure.Repositories.PlayersRepository>();
            services.AddScoped<Services.IPlayersService, Services.PlayersService>();


            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            var context = serviceProvider.GetRequiredService<Infrastructure.Context.FootballClubsManagerContext>();
            AddTestData(context);
          

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=FootballClubs}/{action=Index}/{id?}");
            });
        }

        private void AddTestData(Infrastructure.Context.FootballClubsManagerContext context)
        {
            var rks = new Models.FootballClub
            {
                Id = 1,
                Name = "RKS Radomsko",
                Country = "Poland"
            };

            var wisla = new Models.FootballClub
            {
                Id = 2,
                Name = "Wis³a Kraków",
                Country = "Poland"
            };

            var player1 = new Models.Player
            {
                Age = 33,
                Country = "Poland",
                Name = "Lukasz",
                Surname = "Kowalski",
                ClubName = "RKS Radomsko"
            };

            var player2 = new Models.Player
            {
                Age = 33,
                Country = "Poland",
                Name = "Mateusz",
                Surname = "Barek",
                ClubName = "Wis³a Kraków"
            };

            var player3 = new Models.Player
            {
                Age = 17,
                Country = "Poland",
                Name = "Tomasz",
                Surname = "Markowski",
                ClubName = "RKS Radomsko"
            };

            var player4 = new Models.Player
            {
                Age = 22,
                Country = "Poland",
                Name = "Andrzej",
                Surname = "Kupicha",
                ClubName = "Wis³a Kraków"
            };

            context.Players.Add(player1);
            context.Players.Add(player2);
            context.Players.Add(player3);
            context.Players.Add(player4);
            context.FootballClubs.Add(rks);
            context.FootballClubs.Add(wisla);

            context.SaveChanges();
        }
    }
}
