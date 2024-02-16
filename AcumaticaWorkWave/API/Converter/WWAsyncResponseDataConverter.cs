using AcumaticaWorkWave.API.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AcumaticaWorkWave.API.Converter
{
    public class WWAsyncResponseDataConverter : JsonConverter
    {
        private readonly Type[] _types;

        public WWAsyncResponseDataConverter()
        {
            _types = new Type[] { typeof(WWApiError), typeof(WWAsyncResponseData) };
        }

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var json = token.ToString();

            if (json.Contains("errorCode"))
            {
                return JsonConvert.DeserializeObject<WWApiError>(json);
            }
            else if (json.Contains("created"))
            {
                return JsonConvert.DeserializeObject<WWAsyncResponseData>(json);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}