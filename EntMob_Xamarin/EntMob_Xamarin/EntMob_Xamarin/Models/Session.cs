using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin.Models
{
    public class Session
    {
        public int Id { get; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public User User { get; set; }

        public List<Temperature> Temperatures { get; set; }
        public List<Pressure> Pressures { get; set; }
        public List<Humidity> Humidities { get; set; }
        public List<AcceleroMeter> AcceleroMeters { get; set; }

    }
}
