using AcumaticaWorkWave.API.Converter;
using Newtonsoft.Json;
using System;

namespace AcumaticaWorkWave.API.Domain
{
    public class WWAsyncResponse : WWSyncResponse
    {
        
        [JsonProperty("territoryId")]
        public Guid TerritoryId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        //API returns WWApiError or WWAsyncResponseData
        [JsonProperty("data")]
        [JsonConverter(typeof(WWAsyncResponseDataConverter))]
        public object Data { get; set; }

        [JsonIgnore]
        public string Content { get; set; }
    }
    public class GeocodeStatus
    {
        [JsonProperty("delivery")]
        public string Delivery { get; set; }

        [JsonProperty("pickup")]
        public string Pickup { get; set; }
    }

    public class Pickup
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class Delivery
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class WWChangedOrder
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("geocodeStatus")]
        public GeocodeStatus GeocodeStatus { get; set; }

        [JsonProperty("pickup")]
        public Pickup Pickup { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }
    }
}