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
    public class PerformerRepo : IPerformerRepo
    {
        private ApplicationDbContext context;
        public IQueryable<Performer> Performers
        {
            get
            {
                return context.Performer.Include("News");
            }
        }

        public void AddPerformer(Performer p)
        {
            throw new NotImplementedException();
        }

        public Performer GetById(int id)
        {
            Performer p = context.Performer.Include("News").First(p => p.Id == id);
            return p;
        }

        public bool UpdatePerformer(string id, Performer newP)
        {
            throw new NotImplementedException();
        }
    }
}
