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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FlordiaMan.Repo;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace FlordiaMan.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IEventRepo eRepo;
        ITicketRepo tRepo;
        private readonly IConfiguration _configuration;
        private UserManager<AppUser> userManager;
        public TicketsController(IEventRepo e,UserManager<AppUser>uManager, 
                                    ITicketRepo t, IConfiguration configuration)
        {
            tRepo = t;
            eRepo = e;
            userManager = uManager;
            _configuration = configuration;


        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ticket.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult BuyTicket(int id)
        {
            try
            {
                Event e = eRepo.GetEventById(id);
                return View(e);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BuyTicketAsync(int id, int quantity)
        {
            if(quantity!=0)
            {
                try
                {
                    Event e = eRepo.GetEventById(id);
                    var user = await userManager.GetUserAsync(User);


                    Ticket t = new Ticket();
                    t.EDateTime = e.Date;
                    t.EventName = e.Name;
                    t.Qunatity = quantity;
                    t.Customer = user;

                    tRepo.AddTicket(t);
                    await CreateEmailAsync(user, e, quantity);
                    return View("Confirm");
                }
                catch
                {
                   
                }
            }
            return View("error");




        }
        public async Task<bool> CreateEmailAsync(AppUser user, Event e, int quantity)
        {
            try
            {
                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
                var client = new SendGridClient(apiKey);
                var msg = ("<p>LETS GET READY TO RUMBLE</p>" +
                        "<p>You have booked " + quantity + " tickets to " + e.Name + ". Start time is " + e.Date + "</p>");
                var mail = new SendGridMessage()
                {
                    From = new EmailAddress("Bookings@UFGRU.com"),
                    Subject = "Ticket Booking",
                    HtmlContent = msg
                };
                mail.SetOpenTracking(true);
                mail.AddTo(user.Email, user.Name);
                var response = await client.SendEmailAsync(mail);
                return true;
            }
            catch
            {
                return false;
            }
            return false;

           
        }


    }
}
