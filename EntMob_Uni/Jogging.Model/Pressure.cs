using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model
{
    public class Pressure
    {
        public int Id { get; set; }

        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public Session Session { get; set; }
    }
}
