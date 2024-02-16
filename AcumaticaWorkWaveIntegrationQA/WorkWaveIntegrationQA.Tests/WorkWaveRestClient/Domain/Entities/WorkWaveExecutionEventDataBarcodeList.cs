using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities
{
    [JsonObject(Description = "WorkWave Execution Event Barcode List Data")]
    public class WorkWaveExecutionEventDataBarcodeList
    {
        [JsonProperty("barcodes")]
        public List<WorkWaveExecutionEventDataBarcode> Barcodes { get; set; }
    }

    [JsonObject(Description = "WorkWave Execution Event Barcode Data")]
    public class WorkWaveExecutionEventDataBarcode
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("barcodeStatus")]
        public string BarcodeStatus { get; set; }
        [JsonProperty("sec")]
        public double Sec { get; set; }
    }
}
