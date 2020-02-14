using FlordiaMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo.RepoForTest
{
   public interface IPerformerRepo
    {
        IQueryable<Performer> Performers { get; }

        Performer GetById(int id);
        void AddPerformer(Performer p);
        bool UpdatePerformer(string id, Performer newP);
    }
}
