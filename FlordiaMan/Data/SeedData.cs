﻿using System;
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
                n.Text = "At last weekends Croc n Awe event Cletus became our new Champion!";
                n.Title = "A New Champion";
                n.Date = DateTime.Now;
                context.SaveChanges();

                Performer p = new Performer();
                //p.Id = 1;
                p.ImgUrl = "~/img/skeeter.jpg";
                p.Bio = "Current UFGRU Chamption";
                p.Name = "Cletus";
                p.News.Add(n);
                context.Performer.Add(p);
                context.SaveChanges();

                Performer p2 = new Performer();
                p2.ImgUrl = "~img/bros.jpg";
                p2.Bio = "Tag team extrodinar from deep in the panhandle";
                p2.Name = "The Horse Boys";
                
                context.Performer.Add(p);
                context.SaveChanges();
                Performer p3 = new Performer();
                p.ImgUrl = "~img/BigBessie.jpg";
                p.Bio = "Fan favorite undefeated gator";
                p.Name = "Big Bessie";
                
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
