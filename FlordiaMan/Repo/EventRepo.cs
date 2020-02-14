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
    public class EventRepo : IEventRepo
    {
        private ApplicationDbContext context;

        public IQueryable<Event> Events
        {
            get
            {
                return context.Event.Include("Matches");
            }
        }
        public EventRepo(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public void AddEvent(Event evnt)
        {
            context.Add(evnt);
            context.SaveChanges();
        }

        public Event GetEventByDate(DateTime date)
        {
            var evnt = (from e in context.Event.Include("Matches")
                         where e.Date.Equals(date)
                         select e).ToList();
            Event myEvent = evnt[0];
            return myEvent;
        }
        public void AddMatch(Match m)
        {
          
        }

        public Event GetEventById(int id)
        {
            //var evnt = (from e in context.Event
            //            where e.Id.Equals(id)
            //            select e).ToList();
            //Event myEvent = evnt[0];
            Event myEvent = context.Event.Include("Matches").First(e => e.Id == id);
            return myEvent;
        }
    }
}
