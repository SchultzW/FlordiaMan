using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using FlordiaMan.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlordiaMan.Repo.RepoForTest;
using FlordiaMan.Repo;
using FlordiaMan.Models;

namespace FlordiaMan
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddIdentity<AppUser, IdentityRole>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
            //    opts.Password.RequiredLength = 6;
            //    opts.Password.RequireNonAlphanumeric = false;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = false;
            //    opts.Password.RequireDigit = false;
            //}).AddEntityFrameworkStores<ApplicationDbContext>();




            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(
                Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvc();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IEventRepo, EventRepo>();
            services.AddTransient<INewsRepo, NewsRepo>();
            services.AddTransient<IPerformerRepo, PerformerRepo>();
            services.AddTransient<ITicketRepo, TicketRepo>();
            services.AddTransient<IPostRepo, PostRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            SeedData.Seed(context);
            //ApplicationDbContext.CreateAccounts(app.ApplicationServices, Configuration).Wait();
        }
    }
}
