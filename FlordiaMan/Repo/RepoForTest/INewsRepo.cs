using FlordiaMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Repo.RepoForTest
{
    public interface INewsRepo
    {
        IQueryable<News> News { get; }
        void AddEvent(News news);
        List<News> GetNewsByDate(List<DateTime> date);
        News GetNewsById(int id);
    }
}
