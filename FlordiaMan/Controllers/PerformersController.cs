using System;
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
using System.Text.RegularExpressions;

namespace FlordiaMan.Controllers
{
    public class PerformersController : Controller
    {
        Regex letterNumRegEx = new Regex(@"^[a-zA-Z0-9]+$");
        private readonly ApplicationDbContext _context;
        private IPerformerRepo pRepo;
        private UserManager<AppUser> userManager;
        public PerformersController(ApplicationDbContext context,IPerformerRepo p, UserManager<AppUser> uManager)
        {
            userManager = uManager;
            pRepo = p;
            _context = context;
        }

        // GET: Performers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Performer.ToListAsync());
        }

    




        // GET: Performers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performer = await _context.Performer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        // GET: Performers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Performers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Bio,ImgUrl")] Performer performer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performer);
        }

        // GET: Performers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performer = await _context.Performer.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }
            return View(performer);
        }

        // POST: Performers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Bio,ImgUrl")] Performer performer)
        {
            if (id != performer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformerExists(performer.Id))
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
            return View(performer);
        }

        // GET: Performers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performer = await _context.Performer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        // POST: Performers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performer = await _context.Performer.FindAsync(id);
            _context.Performer.Remove(performer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformerExists(int id)
        {
            return _context.Performer.Any(e => e.Id == id);
        }
        
        [HttpGet]
        public IActionResult PerformersHome()
        {
            var pList = (from p in pRepo.Performers select p).ToList();
            return View(pList);
        }
        [HttpGet]
        public IActionResult PerformerDetails(int id)
        {
            try
            {
                Performer p = pRepo.GetById(id);
                
                return View(p);
            }
            catch
            {
                return View("error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PerformerDetailsAsync(int id, string command)
        {
            var user = await userManager.GetUserAsync(User);
            Performer performer = (from p in pRepo.Performers
                                   where p.Id == id
                                   select p).FirstOrDefault();
            if (command == "add")
            {
                
                user.Favorites.Add(performer);
                return View("PerformersHome");
            }
            else if(command=="remove")
            {
                user.Favorites.Remove(performer);
                return View("PerformersHome");
            }
       
            return View("Error");
        }
        [HttpPost]
        public IActionResult PerformersHome(string searchText)
        {
            try
            {
                if (letterNumRegEx.IsMatch(searchText))
                {
                    var results = (from p in pRepo.Performers
                                   where p.Name.Contains(searchText)
                                   select p).ToList();

                    return View("SearchResult", results);
                }
                else
                    return View("error");
            }
            catch
            {
                return View("error");
            }  
        }
    }
}
