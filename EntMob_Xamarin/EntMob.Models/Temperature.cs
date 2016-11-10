﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob.Models
{
    public class Temperature
    {
        public int Id { get; set; }

        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public Session Session { get; set; }
    }
}
