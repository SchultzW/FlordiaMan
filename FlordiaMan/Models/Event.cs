﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlordiaMan.Models
{
    public class Event
    {
        //public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IList<Match> Matches { get; set; }
    }
}
