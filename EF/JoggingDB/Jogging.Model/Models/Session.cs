using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model.Models
{
   public class Session
    {

        public int Id { get; set; }

        public DateTime End { get; set; }
        public DateTime Start { get; set; }
        public List<Temperature> Temperatures { get; set; }
        public List<Pressure> Pressures { get; set; }
        public List<Humidity> Humidities { get; set; }
        public List<AcceleroMeter> AcceleroMeters { get; set; }

        public Session()
        {

        }
    }
}
