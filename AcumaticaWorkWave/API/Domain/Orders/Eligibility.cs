using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class Eligibility
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("byDate")]
        public string ByDate { get; set; }

        [JsonProperty("onDates")]
        public List<string> OnDates { get; set; }

        public Eligibility WithOnDates()
        {
            OnDates = new List<string>();
            return this;
        }
    }
}