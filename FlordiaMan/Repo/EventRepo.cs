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
            throw new NotImplementedException();
        }

        public Event GetEventByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
