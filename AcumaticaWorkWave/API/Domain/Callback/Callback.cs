using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Callback
{
    public class Callback
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("signaturePassword")]
        public string SignaturePassword { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }
    }
}