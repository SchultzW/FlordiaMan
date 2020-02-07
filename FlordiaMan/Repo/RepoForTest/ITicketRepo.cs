using FlordiaMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo.RepoForTest
{
    public interface ITicketRepo
    {
        IQueryable<Ticket> Tickets { get; }
        void AddTicket(Ticket t);
        Ticket GetTicketByEvent(Event evnt);
        Ticket GetTicketByCustomer(AppUser user);
    }
}
