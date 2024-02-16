using Newtonsoft.Json;
using RestSharp.Serializers;
using System.IO;
using RestSharp;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRestJsonSerializer : IRestSerializer, IDeserializer
    {
        private readonly JsonSerializer _serializer;

        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string ContentType { get; set; }

        public WWRestJsonSerializer()
        {
            ContentType = "application/json";
            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                Formatting = Formatting.Indented
            };

            _serializer = JsonSerializer.Create(settings);
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        public T Deserialize<T>(RestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public string Serialize(Parameter parameter) => Serialize(parameter.Value);

        public ISerializer Serializer { get; } 
        public IDeserializer Deserializer { get; }
        public string[] AcceptedContentTypes { get; } = { "application/json", "text/json", "text/x-json", "text/javascript", "*+json"};
        public SupportsContentType SupportsContentType { get; } = SupportsContentTypeFunc;

        private static bool SupportsContentTypeFunc(string contentType)
        {
            switch (contentType)
            {
                case "application/json":
                case "text/json":
                case "text/x-json":
                case "text/javascript":
                case "*+json":
                    return true;
                default:
                    return false;
                
            }
        }

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}
