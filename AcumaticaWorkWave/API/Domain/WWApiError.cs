using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain
{
    [JsonObject(Description = "WW API Error")]
    public class WWApiError
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}