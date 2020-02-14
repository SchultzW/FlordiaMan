using FlordiaMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo.RepoForTest
{
    public interface IPostRepo
    {
        IQueryable<Post> Posts { get; }
        void AddReply(string text, int id, AppUser user);
        IList<Reply> GetReplies();
        Post GetPostById(int id);
        void AddPost(Post p);
    }
}
