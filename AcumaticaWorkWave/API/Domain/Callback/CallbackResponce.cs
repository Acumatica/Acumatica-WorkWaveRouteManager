using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Callback
{
    public class CallbackResponce
    {
        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("previousUrl")]
        public string PreviousUrl { get; set; }
    }
}