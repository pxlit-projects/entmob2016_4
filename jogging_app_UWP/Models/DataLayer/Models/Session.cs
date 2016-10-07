using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    class Session
    {
        private int id { get; }
        private DateTime end { get; set; }
        private DateTime start { get; set; }
        private List<Temperature> temperatures { get; set; }
        private List<Pressure> pressures { get; set; }
        private List<Humidity> humidities { get; set; }
        private List<AcceleroMeter> acceleroMeters { get; set; }

        public session()
        {

        }
    }
}
