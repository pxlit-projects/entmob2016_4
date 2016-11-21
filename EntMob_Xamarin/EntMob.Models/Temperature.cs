using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models.JsonConverters;
using Newtonsoft.Json;

namespace EntMob.Models
{
    public class Temperature
    {
		[JsonProperty("id")]
        public int Id { get; set; }

		[JsonProperty("temperature")]
        public string Amount { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("date")]
        public DateTime Date { get; set; }

		[JsonProperty("session")]
		public Session Session { get; set;}

    }
}
