using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Post
    {
        public int Id { get; set; }

        
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$")]
        public string PostTopic { get; set; }
        public AppUser Op { get; set; }

        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$")]
        public string PostText { get; set; }
        

        private List<Reply> replies = new List<Reply>();
        public IList<Reply> Replies { get { return replies; } }
    }
}
