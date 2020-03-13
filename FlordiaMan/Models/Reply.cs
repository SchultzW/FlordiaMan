using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$")]
        public string Text { get; set; }
        public AppUser User { get; set; }
    }
}
