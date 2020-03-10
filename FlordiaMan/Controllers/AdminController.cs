using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlordiaMan.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        private IEventRepo eRepo;
        private IPerformerRepo pRepo;

        private SignInManager<AppUser> signInManager;

        public AdminController(UserManager<AppUser> usrMgr,
               IUserValidator<AppUser> userValid,
               IPasswordValidator<AppUser> passValid,IPerformerRepo performerRepo,
               IPasswordHasher<AppUser> passwordHash, SignInManager<AppUser> signInMgr,IEventRepo eventRepo)
        {
            pRepo = performerRepo;
            signInManager = signInMgr;
            eRepo = eventRepo;
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserIndex()
        {
            return View();
        }
        public IActionResult NewsIndex()
        {
            return View();
        }
        public IActionResult PerformerIndex()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(AppUser model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Email.Trim(),
                    Email = model.Email.Trim(),
                    Name = model.Name.Trim()
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError e in result.Errors)
                    {
                        ModelState.AddModelError(" ", e.Description);
                    }
                }

            }
            return View(model);


        }
        ///MatchMaker 
        [HttpGet]
        public IActionResult Build(int id)
        {

            var events = (from myEvent in eRepo.Events
                    where myEvent.Id == id
                    select myEvent).ToList();
            Event e = events[0];
            e.SortMatch();
            return View(e);
        }
        [HttpGet]
        public IActionResult EventBuilder()
        {
            List<Event> events = (from e in eRepo.Events
                                  select e).ToList();
            return View(events);
        }
        [HttpGet]
        public IActionResult MatchMake()
        {
            List<Performer> p = (from performer in pRepo.Performers
                                 select performer).ToList();
            return View(p); 
        }
        [HttpPost]
        public IActionResult MatchMake(int performer1, int performer2, int placement)
        {


            return View();
        }
     
    }
}