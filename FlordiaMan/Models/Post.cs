using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostTopic { get; set; }
        public AppUser Op { get; set; }
        public string PostText { get; set; }
        

        private List<Reply> replies = new List<Reply>();
        public IList<Reply> Replies { get { return replies; } }
    }
}
