using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlordiaMan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FlordiaMan.Data
{
    public class ApplicationDbContext : IdentityDbContext//<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<FlordiaMan.Models.Event> Event { get; set; }
        public DbSet<FlordiaMan.Models.Match> Match { get; set; }
        public DbSet<FlordiaMan.Models.Performer> Performer { get; set; }
        public DbSet<FlordiaMan.Models.News> News { get; set; }
        public DbSet<FlordiaMan.Models.Ticket> Ticket { get; set; }



        public static async Task CreateAccounts(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<AppUser> userManager =
              serviceProvider.GetRequiredService<UserManager<AppUser>>();

            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string userName = configuration["Data:Adminuser:Email"];
            string email = configuration["Data:Adminuser:Email"];
            string name = configuration["Data:Adminuser:Name"];
            string password = configuration["Data:Adminuser:Password"];
            string role = configuration["Data:Adminuser:Role"];


            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser
                {
                    UserName = userName,
                    Email = email,
                    Name = name,
                  
                };
                IdentityResult result = await userManager
                .CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
             userName = configuration["Data:Member:Email"];
             email = configuration["Data:Member:Email"];
             name = configuration["Data:Member:Name"];
             password = configuration["Data:Member:Password"];
             role = configuration["Data:Member:Role"];


            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser
                {
                    UserName = userName,
                    Email = email,
                    Name = name,

                };
                IdentityResult result = await userManager
                .CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }



        public DbSet<FlordiaMan.Models.Post> Post { get; set; }



        public DbSet<FlordiaMan.Models.Reply> Reply { get; set; }
      


    }
}
