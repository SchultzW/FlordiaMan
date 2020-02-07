using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Match
    {
        public int Id { get; set; }
        public IList<Performer> Performers { get; set; }
        public Performer Winner { get; set; }
    }
}
