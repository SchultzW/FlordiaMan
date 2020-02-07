using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public IList<Performer> Favorites { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}
