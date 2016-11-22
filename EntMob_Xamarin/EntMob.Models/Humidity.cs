using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models.JsonConverters;
using Newtonsoft.Json;

namespace EntMob.Models
{
    public class Humidity
    {
		[JsonProperty("id")]
        public int Id { get; set; }

		[JsonProperty("humidity")]
        public float Amount { get; set; }
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }

		[JsonProperty("session")]
        public Session Session { get; set; }
    }
}
