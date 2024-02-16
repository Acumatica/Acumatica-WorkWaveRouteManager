using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Territories
{
    public class Territory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("center")]
        public List<int> Center { get; set; }

        [JsonProperty("timeZoneCode")]
        public string TimeZoneCode { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }
}