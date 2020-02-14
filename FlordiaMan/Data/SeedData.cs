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
            if(!context.News.Any())
            {
                News n = new News();
                //n.Id = 1;
                n.Text = "test";
                n.Title = "test";
                n.Date = DateTime.Now;
                context.SaveChanges();

                Performer p = new Performer();
                //p.Id = 1;
                p.ImgUrl = "url";
                p.Bio = "test";
                p.Name = "test";
                p.News.Add(n);
                context.Performer.Add(p);
                context.SaveChanges();

                Match m = new Match();
                //m.Id = 1;
                m.Performers.Add(p);
                m.Winner = p;
                context.SaveChanges();

                Event myEvent = new Event();
                //myEvent.Id = 1;
                myEvent.Name = "test";
                
                myEvent.Matches.Add(m);
                myEvent.Date = DateTime.Now;
                context.Event.Add(myEvent);
                context.SaveChanges();

                
            }
           
        }
    }
}
