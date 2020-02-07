using FlordiaMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo.RepoForTest
{
    interface IEventRepo
    {
        IQueryable<Event> Events { get; }
        void AddEvent(Event evnt);
        Event GetEventByDate(DateTime date);
        Event GetEventById(int id);

    }
}
