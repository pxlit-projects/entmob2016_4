using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin.Models
{
    public class AcceleroMeter
    {
        public int Id { get; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public DateTime Date { get; set; }

        public Session Session { get; set; }
    }
}
