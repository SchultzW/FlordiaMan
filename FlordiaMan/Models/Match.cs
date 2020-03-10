using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Placement { get; set; }
        private List<Performer> performers = new List<Performer>();
        public IList<Performer> Performers { get { return performers; } }
        public Performer Winner { get; set; }



    }
}
