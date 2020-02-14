using FlordiaMan.Data;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo
{
    public class TicketRepo : ITicketRepo
    {
        ApplicationDbContext context;
        public IQueryable<Ticket> Tickets
        {
            get
            {
                return context.Ticket.Include("User");
            }
        }

        public void AddTicket(Ticket t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public Ticket GetTicketByCustomer(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketByEvent(Event evnt)
        {
            throw new NotImplementedException();
        }
    }
}
