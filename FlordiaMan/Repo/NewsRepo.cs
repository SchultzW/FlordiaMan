using FlordiaMan.Data;
using FlordiaMan.Models;
using FlordiaMan.Repo.RepoForTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo
{
    public class NewsRepo : INewsRepo
    {
        private ApplicationDbContext context;

        public IQueryable<News> News 
        {
            get { return context.News; }
        }
        public NewsRepo(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public void AddEvent(News news)
        {
            context.News.Add(news);
            context.SaveChanges();
        }

        public List<News> GetNewsByDate(List<DateTime> date)
        {
            List<News> news = new List<News>();
            news = (from n in context.News
                   where n.Date.Equals(date)
                   select n).ToList();

            return news;
        }

        public News GetNewsById(int id)
        {
            News news = context.News.First(n => n.Id == id);
            return news;
        }
    }
}
