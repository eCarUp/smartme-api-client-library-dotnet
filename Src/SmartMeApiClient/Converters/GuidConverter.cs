using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeApiClient.Converters
{
    /// <summary>
    /// An empty Guid must be serialized to an empty string for the smart-me API.
    /// This is achieved with this JsonConverter.
    /// </summary>
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Guid);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new Guid(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Guid guid = (Guid)value;

            // Serialize empty Guid as ""
            if (guid.CompareTo(new Guid()) == 0)
            {
                writer.WriteValue("");
            }
            else
            {
                writer.WriteValue(guid.ToString());
            }
        }
    }
}
