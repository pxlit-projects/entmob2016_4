﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    class Temperature
    {
        private int id { get; }
        private float temperature { get; set;}
        private DateTime date { get; set; }
        private Session session { get; set; }
    }
}
