using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public AppUser Customer { get; set; }
        public int Qunatity { get; set; }
    }
}
