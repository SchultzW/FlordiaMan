using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FlordiaMan.Data;
using Microsoft.EntityFrameworkCore;

namespace FlordiaMan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        INewsRepo nRepo;
        private UserManager<AppUser> userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, INewsRepo n, UserManager<AppUser> uManager, ApplicationDbContext context)
        {
            _context = context;
            nRepo = n;
            _logger = logger;
            userManager = uManager;
        }

        public IActionResult Index()
        {
            List<News> news = (from n in nRepo.News
                               orderby n.Date
                               select n).OrderByDescending(n => n.Date)
                          .Take(5)
                          .ToList();

                        

            return View(news);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> ProfileAsync()
        {


            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var results = (from u in _context.Users.Include("Favorites").Include("Tickets")
                           where u.UserName == user.UserName
                           select u).FirstOrDefault();




            return View(results);
        }
    }
}
