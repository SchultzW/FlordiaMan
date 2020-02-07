using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlordiaMan.Models;

namespace FlordiaMan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FlordiaMan.Models.Event> Event { get; set; }
        public DbSet<FlordiaMan.Models.Match> Match { get; set; }
        public DbSet<FlordiaMan.Models.Performer> Performer { get; set; }
        public DbSet<FlordiaMan.Models.News> News { get; set; }
        public DbSet<FlordiaMan.Models.Ticket> Ticket { get; set; }
    }
}
