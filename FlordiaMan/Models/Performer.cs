using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Special { get; set; }
        public string ImgUrl { get; set; }

        public IList<News> News { get; set; }
    }
}
