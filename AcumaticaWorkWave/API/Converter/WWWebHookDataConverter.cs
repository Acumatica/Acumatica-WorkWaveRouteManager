using AcumaticaWorkWave.API.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AcumaticaWorkWave.API.Converter
{
    public class WWWebHookDataConverter : JsonConverter
    {
        private readonly Type[] _types;

        public WWWebHookDataConverter()
        {
            _types = new Type[] { typeof(WWAsyncResponsePlain), typeof(WWAsyncResponse), typeof(object) };
        }

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var json = token.ToString();
            var test = "test";

            try
            {
                var plain = JsonConvert.DeserializeObject<WWAsyncResponsePlain>(json);
                if (plain.RequestId == test && plain.TerritoryId == test && plain.Event == test && plain.Data.ToString() == test)
                {
                    return plain;
                }
                else
                {
                    return JsonConvert.DeserializeObject<WWAsyncResponse>(json);
                }
            }
            catch (Exception)
            {
                return JsonConvert.DeserializeObject(json);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}