using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob.Models
{
    public class Humidity
    {
        public int Id { get; set; }

        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public Session Session { get; set; }
    }
}
