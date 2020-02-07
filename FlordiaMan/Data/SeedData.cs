using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlordiaMan.Models;

namespace FlordiaMan.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            Performer p = new Performer();
            p.Id = 1;
            p.ImgUrl = "url";
            p.Special = "test";
            p.Name = "test";

            Match m = new Match();
            m.Id = 1;
            m.Performers.Add(p);
            m.Winner = p;

            Event myEvent= new Event();
            myEvent.Id = 1;
            myEvent.Matches.Add(m);
            myEvent.Date = DateTime.Now;
        }
    }
}
