using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    class Pressure
    {
        private int id { get; }
        private float pressure { get; set; }
        private DateTime date { get; set; }
        private Session session { get; set; }

        public Pressure()
        {

        }
    }
}
