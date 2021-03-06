﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlordiaMan.Data;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FlordiaMan.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;
        IPostRepo pRepo;
        private readonly UserManager<AppUser> userManager;

        public ForumController(IPostRepo p,UserManager<AppUser>usrMgr)
        {
            userManager = usrMgr;
            pRepo = p;
            
        }

        // GET: Posts
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Post.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostTopic,PostText")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostTopic,PostText")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Forum()
        {
            List<Post> posts = (from p in pRepo.Posts
                                select p).Include("Op").Include("Replies").OrderBy(p => p.Id).ToList();


            return View(posts);
            
        }
       [HttpGet]
       public IActionResult AddReply(int id)
       {
            ViewBag.id = id;
;            return View();
       }
       [HttpPost]
       public async Task<IActionResult> AddReplyAsync(int id, string name, string text)
       {
            try
            {
                if(ModelState.GetValidationState(nameof(text))== ModelValidationState.Valid)
                {
                    AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                    pRepo.AddReply(text, id, user);
                    return View();

                }
                return View("Error");


            }
            catch
            {
                return View("Error");
            }
       }
       [HttpGet]
       public IActionResult AddPost()
       {
            return View();
       }
       [HttpPost]
       public async Task<IActionResult> AddPostAsync(String postText, String postTopic)
       {
            if (ModelState.GetValidationState(nameof(postText)) == ModelValidationState.Valid)
            {
                Post p = new Post
                {
                    PostTopic = postTopic,
                    PostText = postText,
                    Op = await userManager.GetUserAsync(User)
                };
                pRepo.AddPost(p);
                return View();
            }
            else
                return View("error");
       }
        
    }
}
