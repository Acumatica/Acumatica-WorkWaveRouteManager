using Newtonsoft.Json;

namespace AcumaticaWorkWave.API.Domain.Drivers
{
    class Driver
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("GpsDeviceId")]
        public string gpsDeviceId { get; set; }
    }
}
