using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class OrderStep
    {
        [JsonProperty("depotId")]
        public object DepotId { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("timeWindows")]
        public List<TimeWindow> TimeWindows { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("serviceTimeSec")]
        public int ServiceTimeSec { get; set; }

        [JsonProperty("tagsIn")]
        public List<string> TagsIn { get; set; }

        [JsonProperty("tagsOut")]
        public List<string> TagsOut { get; set; }

        [JsonProperty("barcodes")]
        public List<string> Barcodes { get; set; }

        [JsonProperty("customFields")]
        public Dictionary<string, string> CustomFields { get; set; }

        public OrderStep WithLocation()
        {
            Location = new Location();
            return this;
        }
        public OrderStep WithTimeWindows()
        {
            TimeWindows = new List<TimeWindow>();
            return this;
        }
        public OrderStep WithTagsIn()
        {
            TagsIn = new List<string>();
            return this;
        }
        public OrderStep WithTagsOut()
        {
            TagsOut = new List<string>();
            return this;
        }
        public OrderStep WithBarcodes()
        {
            Barcodes = new List<string>();
            return this;
        }
        public OrderStep WithCustomFields()
        {
            CustomFields = new Dictionary<string, string>();
            return this;
        }
    }
}