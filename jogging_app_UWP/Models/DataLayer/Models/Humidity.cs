using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Humidity
    {
        private int id { get;  }
        private float humidity { get; set; }
        private Date date { get; set; }
        private Session session { get; set; }

        public Humidity()
        {

        }
    }
}
