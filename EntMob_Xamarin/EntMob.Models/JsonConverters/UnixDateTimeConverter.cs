using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EntMob.Models.JsonConverters
{
    class UnixDateTimeConverter: JsonConverter
    {

        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			var test = reader.Value;
			if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            return _epoch.AddMilliseconds((long)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			DateTime time = (DateTime)value;
			if (time != new DateTime())
			{
				long mili = (long)(time - _epoch).TotalMilliseconds;
				writer.WriteValue(mili);
			}
			else {
				writer.WriteNull();
			}
        }

    }
}
