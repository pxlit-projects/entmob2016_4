using Jogging.Model.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model
{
    public class Session
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("start")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Start { get; set; }
        [JsonProperty("end")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime End { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonIgnore]
        public double AverageTemperature { get; set; }
        [JsonIgnore]
        public double AverageHumidity { get; set; }
        [JsonIgnore]
        public double AverageActivity { get; set; }
        [JsonIgnore]
        public double AveragePressure { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return End - Start;
            }
        }

    }
}
