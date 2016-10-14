using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model.Models
{
   public class Humidity
    {
        public int Id { get; set; }
        public float Humid { get; set; }
        public DateTime Date { get; set; }
        public Session Session { get; set; }

        public Humidity()
        {

        }
    }
}
