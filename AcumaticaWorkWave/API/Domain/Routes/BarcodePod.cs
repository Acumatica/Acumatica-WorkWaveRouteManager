using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class BarcodePod
    {
        [JsonProperty("sec")]
        public int Sec { get; set; }

        [JsonProperty("latLng")]
        public List<int> LatLng { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("barcodeStatus")]
        public string BarcodeStatus { get; set; }
    }
}