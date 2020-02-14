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
        public string Bio { get; set; }//Bio text
        public string ImgUrl { get; set; }

        private List<News> news = new List<News>();
        public IList<News> News { get { return news; } }
    }
}
