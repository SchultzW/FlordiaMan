using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlordiaMan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlordiaMan.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
       
        private SignInManager<AppUser> signInManager;

        public AdminController(UserManager<AppUser> usrMgr,
               IUserValidator<AppUser> userValid,
               IPasswordValidator<AppUser> passValid,
               IPasswordHasher<AppUser> passwordHash, SignInManager<AppUser> signInMgr)
        {
            signInManager = signInMgr;
          
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
            if(ModelState.IsValid)
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
     
    }
}