using Newtonsoft.Json;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Client
{
    public class WWResponseContent
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("errors")]
        public List<WWResponseError> Errors { get; set; }
    }

    public class WWResponseError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}