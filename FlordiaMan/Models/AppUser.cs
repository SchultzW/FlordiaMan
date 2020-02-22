using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class AppUser:IdentityUser
    {

        [Required(ErrorMessage = "Please enter a first name")]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Please enter a first name")]
        public string Name { get; set; }
        public IList<Performer> Favorites { get; set; }
        public IList<Ticket> Tickets { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password that is at least 8 characters")]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }

    }
}
