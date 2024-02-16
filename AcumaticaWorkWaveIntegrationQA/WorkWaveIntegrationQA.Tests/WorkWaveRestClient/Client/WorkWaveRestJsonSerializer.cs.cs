﻿using System.IO;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveRestJsonSerializer : ISerializer, IDeserializer
    {
        private readonly JsonSerializer _serializer;
        public WorkWaveRestJsonSerializer()
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

        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string ContentType { get; set; }

        public T Deserialize<T>(RestSharp.IRestResponse response)
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
    }
}
