using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public AppUser User { get; set; }
    }
}
