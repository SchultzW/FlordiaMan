using FlordiaMan.Data;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo
{
    public class PostRepo : IPostRepo
    {
        private ApplicationDbContext context;
        public PostRepo(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IQueryable<Post> Posts
        {
            get
            {
                return context.Post;
            }
        }

        public void AddPost(Post p)
        {
            context.Add(p);
            context.SaveChanges();
        }

     

        public void AddReply(string text, int id, AppUser user )
        {
            Reply r = new Reply();
            r.Text = text;
            r.User = user;
            context.Post.Find(id).Replies.Add(r);
            context.SaveChanges();
            
        }

        public Post GetPostById(int id)
        {
            Post post = Posts.First(p => p.Id == id);
            return post;
        }

        public IList<Reply> GetReplies()
        {
            throw new NotImplementedException();
        }
    }
}
